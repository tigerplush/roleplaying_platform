using Corgi.Backend.Enums;

namespace Corgi.Backend.Models
{
    public class TemplateField : ICreatedAt, ILastModified
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public FieldType FieldType { get; set; }
        public string Value { get; set; }
        public bool IsVisible { get; set; } = true;
        public Template Owner { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastModified { get; set; }
    }
}
