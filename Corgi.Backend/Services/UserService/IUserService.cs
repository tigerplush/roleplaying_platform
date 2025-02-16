using Corgi.Backend.Models;

namespace Corgi.Backend.Services.UserService
{
    public interface IUserService
    {
        public Task<User> CreateNewUserAsync(Guid id, string name);
        public Task<User> GetUserByIdAsync(Guid id);
        public Task<User> UpdateUserAsync(User user);
    }
}
