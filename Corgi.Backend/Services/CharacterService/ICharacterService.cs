using Corgi.Backend.Models;

namespace Corgi.Backend.Services.CharacterService
{
    public interface ICharacterService
    {
        public Task<Character> GetCharacterById(Guid id);
    }
}
