using Corgi.Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Corgi.Backend.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private readonly DatabaseContext _context;
        public CharacterService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Character> GetCharacterById(Guid id)
        {
            return await _context
                .Characters
                .FirstOrDefaultAsync(character => character.Id == id);
        }
    }
}
