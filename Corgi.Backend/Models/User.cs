namespace Corgi.Backend.Models
{
    public class User : ICreatedAt, ILastModified
    {
        public Guid Id { get; set; }
        public List<Character> Characters { get; set; } = new List<Character>();
        public DateTime CreatedAt { get; set; }
        public DateTime LastModified { get; set; }
    }
}
