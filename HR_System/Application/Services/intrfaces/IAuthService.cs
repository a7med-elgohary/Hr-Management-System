using static HR_System.Application.Services.AuthService;

namespace HR_System.Application.Services.intrfaces
{
    public interface IAuthService
    {
        public Task<string?> LoginAsync(string username, string password);
        public Task<RegisterResult> RegisterAsync(object registerRequestObj);
    }
}
