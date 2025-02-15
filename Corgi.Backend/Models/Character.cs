
namespace Corgi.Backend.Models
{
    public class Character : ICreatedAt, ILastModified
    {
        public Guid Id { get; set; }
        public User Owner { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastModified { get; set; }
    }
}
