using AutoMapper;
using Corgi.Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Corgi.Backend.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public CharacterService(
            DatabaseContext context
            , IMapper mapper
            )
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<Character[]> GetAllCharactersAsync()
        {
            return await _context.Characters.ToArrayAsync();
        }

        public async Task<Character> GetCharacterByIdAsync(Guid id)
        {
            return await _context
                .Characters
                .Where(character => character.Id == id)
                .Include(character => character.Template)
                .Include(character => character.Fields.OrderBy(field => field.CreatedAt))
                .ThenInclude(field => field.Origin)
                .FirstOrDefaultAsync();
        }

        public async Task<Character> AddCharacterAsync(Template template, string name)
        {
            Character character = new()
            {
                Name = name
                , Template = template
                , Fields = _mapper.Map<List<CharacterField>>(template.Fields)
            };
            await _context.Characters.AddAsync(character);
            await _context.SaveChangesAsync();
            return character;
        }
    }
}
