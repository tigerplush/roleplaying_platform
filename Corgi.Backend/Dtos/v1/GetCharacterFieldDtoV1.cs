using Corgi.Backend.Enums;
using Corgi.Backend.Models;
using System.Text.Json.Serialization;

namespace Corgi.Backend.Dtos.v1
{
    public class GetCharacterFieldDtoV1
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public FieldType FieldType { get; set; }
        public string Value { get; set; }
        public bool IsVisible { get; set; }
        public Guid Origin { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastModified { get; set; }
    }
}
