using Corgi.Backend.Enums;

namespace Corgi.Backend.Models
{
    public class CharacterField : ICreatedAt, ILastModified
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public FieldType FieldType { get; set; }
        public string Value { get; set; }
        public bool IsVisible { get; set; }
        public TemplateField Origin { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastModified { get; set; }
    }
}
