using HR_System.Domain.Models;

namespace HR_System.Infrastructure.Intefaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User?> GetByUsernameAsync(string username);
        Task<User?> GetByEmailAsync(string email);
        Task<List<string>> GetRolesAsync(long userId);
        Task<List<string>> GetPermissionsAsync(long userId);
        Task<bool> ExistsByUsernameAsync(string username);
        public Task<bool> ExistsByEmailAsync(string email);
        Task AddAsync(User newuser);
    }
}
