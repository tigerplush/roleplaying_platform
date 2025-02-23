using Corgi.Backend.Models;

namespace Corgi.Backend.Dtos.v1
{
    public class GetCharacterDtoV1
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public User Owner { get; set; }
        public Guid Template { get; set; }
        public List<GetCharacterFieldDtoV1> Fields { get; set; } = [];
        public DateTime CreatedAt { get; set; }
        public DateTime LastModified { get; set; }
    }
}
