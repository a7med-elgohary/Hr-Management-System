using HR_System.Domain.Models;
using HR_System.Infrastructure.Repository.Intefaces;
using Microsoft.EntityFrameworkCore;

namespace HR_System.Infrastructure.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext dbContext) : base(dbContext) { }

        public async Task<User?> GetByUsernameAsync(string username)
        {
            return await _dbContext.Users
                .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
                .FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _dbContext.Users
                .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<List<string>> GetRolesAsync(long userId)
        {
            return await _dbContext.UserRoles
                .Where(ur => ur.UserId == userId)
                .Select(ur => ur.Role.Name)
                .ToListAsync();
        }

        public async Task<List<string>> GetPermissionsAsync(long userId)
        {
            return await _dbContext.UserRoles
                .Where(ur => ur.UserId == userId)
                .SelectMany(ur => ur.Role.RolePermissions)
                .Select(rp => rp.Permission.Name)
                .Distinct()
                .ToListAsync();
        }

        public async Task<bool> ExistsByUsernameAsync(string username)
        {
            return await _DbSet.AnyAsync(u => u.Username == username);
        }

        public async Task<bool> ExistsByEmailAsync(string email)
        {
            return await _DbSet.AnyAsync(u => u.Email == email);
        }
    }
}
