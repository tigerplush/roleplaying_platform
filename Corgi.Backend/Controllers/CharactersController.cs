using Corgi.Backend.Models;
using Corgi.Backend.Services.CharacterService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Corgi.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharactersController : ControllerBase
    {
        private readonly ICharacterService _characterService;
        public CharactersController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        [HttpGet]
        public async Task<ActionResult<Character>> GetCharacterByIdAsync()
        {
            Character character = await _characterService.GetCharacterByIdAsync(Guid.NewGuid());
            if (character == null)
            {
                return NotFound();
            }
            return Ok(character);
        }

        [HttpPost]
        public async Task<ActionResult<Character>> AddCharacterAsync()
        {
            Character charcater = await _characterService.AddCharacterAsync();
            return Ok(charcater);
        }
    }
}
