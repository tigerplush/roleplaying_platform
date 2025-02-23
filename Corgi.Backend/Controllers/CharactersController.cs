using AutoMapper;
using Corgi.Backend.Dtos.v1;
using Corgi.Backend.Models;
using Corgi.Backend.Services.CharacterService;
using Corgi.Backend.Services.TemplateService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Corgi.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharactersController : ControllerBase
    {
        private readonly ICharacterService _characterService;
        private readonly ITemplateService _templateService;
        private readonly IMapper _mapper;

        public CharactersController(
            ICharacterService characterService
            , ITemplateService templateService
            , IMapper mapper
            )
        {
            _characterService = characterService;
            _templateService = templateService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetCharacterDtoV1>> GetCharacterByIdAsync([FromRoute] Guid id)
        {
            Character character = await _characterService.GetCharacterByIdAsync(id);
            if (character == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<GetCharacterDtoV1>(character));
        }

        [HttpPost]
        [ProducesResponseType(typeof(GetCharacterDtoV1), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GetCharacterDtoV1>> AddCharacterAsync(AddCharacterDtoV1 newCharacter)
        {
            Template template = await _templateService.GetTemplateByIdAsync(newCharacter.Template);
            if(template == null)
            {
                return BadRequest();
            }
            Character character = await _characterService.AddCharacterAsync(template, newCharacter.Name);
            return Ok(_mapper.Map<GetCharacterDtoV1>(character));
        }
    }
}
