using Corgi.Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Corgi.Backend.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly DatabaseContext _context;

        public UserService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<User> CreateNewUserAsync(Guid id, string name)
        {
            User user = new()
            {
                Id = id,
                Name = name
            };
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> GetUserByIdAsync(Guid id)
        {
            return await _context
                .Users
                .FirstOrDefaultAsync(user => user.Id == id);
        }
    }
}
