using HR_System.Application.intrfaces;
using HR_System.Domain.Models;
using HR_System.Infrastructure.Intefaces;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HR_System.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _config;

        public AuthService(IUserRepository userRepository, IConfiguration config)
        {
            _userRepository = userRepository;
            _config = config;
        }

        public async Task<string?> LoginAsync(string Email, string password)
        {
            var user = await _userRepository.GetByUsernameAsync(Email);
            if (user == null)
                return null;

            if (!BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
                return null;

            // record last login date
            user.LastLoginDate = DateTime.UtcNow;
            await _userRepository.UpdateAsync(user);

            var roles = await _userRepository.GetRolesAsync(user.Id);
            var permissions = await _userRepository.GetPermissionsAsync(user.Id);
            //claims
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };
            claims.AddRange(roles.Select(r => new Claim(ClaimTypes.Role, r)));
            claims.AddRange(permissions.Select(p => new Claim("permission", p)));

            var jwtKey = _config["Jwt:Key"];
            if (string.IsNullOrEmpty(jwtKey))
                throw new InvalidOperationException("JWT key is not configured properly.");

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(20),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<RegisterResult> RegisterAsync(object registerRequestObj)
        {
            var request = registerRequestObj as dynamic;
            string username = request.Username;
            string email = request.Email;
            string password = request.Password;
            long employeeId = request.EmployeeId;

            // تحقق من أن اليوزرنيم أو الإيميل غير مستخدمين
            if (await _userRepository.ExistsByUsernameAsync(username))
                return new RegisterResult { Success = false, ErrorMessage = "Username already exists" };
            if (await _userRepository.ExistsByEmailAsync(email))
                return new RegisterResult { Success = false, ErrorMessage = "Email already exists" };

            // تشفير كلمة السر
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

            // إنشاء المستخدم
            var user = new User
            {
                Username = username,
                Email = email,
                PasswordHash = hashedPassword,
                EmployeeId = employeeId  ,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };
            await _userRepository.AddAsync(user);

            // (اختياري) توليد توكن مباشرة بعد التسجيل
            var token = await LoginAsync(username, password);
            return new RegisterResult { Success = true, Token = token };
        }

        public class RegisterResult
        {
            public bool Success { get; set; }
            public string? Token { get; set; }
            public string? ErrorMessage { get; set; }
        }
    }
}