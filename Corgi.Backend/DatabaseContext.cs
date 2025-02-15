using Corgi.Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Corgi.Backend
{
    public class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Character> Characters { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options)
        {
        }
    }
}
