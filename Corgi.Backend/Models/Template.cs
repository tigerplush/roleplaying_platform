namespace Corgi.Backend.Models
{
    public class Template : ICreatedAt, ILastModified
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<TemplateField> Fields { get; set; } = [];
        public DateTime CreatedAt { get; set; }
        public DateTime LastModified { get; set; }
    }
}
