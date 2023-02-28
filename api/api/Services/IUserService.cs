using api.Models;

namespace api.Services
{
    public interface IUserService : IService<User>
    {
        Task<User?> GetByEmailAsync(string email);
        Task<User?> GetByIdAsync(int id);
        Task<bool> IsEmailTakenAsync(string email, int? userId = null);
    }
}
