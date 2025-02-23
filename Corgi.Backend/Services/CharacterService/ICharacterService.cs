using Corgi.Backend.Models;

namespace Corgi.Backend.Services.CharacterService
{
    public interface ICharacterService
    {
        public Task<Character[]> GetAllCharactersAsync();
        public Task<Character> GetCharacterByIdAsync(Guid id);
        public Task<Character> AddCharacterAsync(Template template, string name);
    }
}
