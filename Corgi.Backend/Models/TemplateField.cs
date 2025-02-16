namespace Corgi.Backend.Models
{
    public class TemplateField : ICreatedAt, ILastModified
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Template Owner { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastModified { get; set; }
    }
}
