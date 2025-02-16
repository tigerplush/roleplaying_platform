using Corgi.Backend.Models;

namespace Corgi.Backend.Dtos.v1
{
    public class GetUserDtoV1
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<GetCharacterDtoV1> Characters { get; set; } = [];
        public DateTime CreatedAt { get; set; }
        public DateTime LastModified { get; set; }
    }
}
