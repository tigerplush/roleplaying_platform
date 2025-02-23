using Corgi.Backend.Enums;
using System.Text.Json.Serialization;

namespace Corgi.Backend.Dtos.v1
{
    public class UpdateTemplateFieldDtoV1
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public FieldType FieldType { get; set; }
        public string Value { get; set; }
        public bool IsVisible { get; set; } = true;
    }
}
