using AutoMapper;
using Corgi.Backend.Dtos.v1;
using Corgi.Backend.Models;
using Corgi.Backend.Services.TemplateService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Corgi.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemplatesController : ControllerBase
    {
        private readonly ITemplateService _templateService;
        private readonly IMapper _mapper;

        public TemplatesController(
            ITemplateService templateService
            , IMapper mapper
            )
        {
            _templateService = templateService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<TemplateResponseDtoV1>> GetAllTemplatesAsync()
        {
            Template[] templates = await _templateService.GetAllTemplatesAsync();
            return Ok(new TemplateResponseDtoV1()
            {
                Templates = _mapper.Map<GetTemplateDtoV1[]>(templates)
            });
        }

        [HttpPost]
        [ProducesResponseType(typeof(GetTemplateDtoV1), StatusCodes.Status200OK)]
        public async Task<ActionResult<GetTemplateDtoV1>> CreateNewTemplateAsync(AddTemplateDtoV1 newTemplate)
        {
            Template template = await _templateService.CreateNewTemplateAsync(newTemplate.Name);
            return Ok(_mapper.Map<GetTemplateDtoV1>(template));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteTemplateAsync([FromRoute] Guid id)
        {
            bool success = await _templateService.DeleteTemplateAsync(id);
            if(!success)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPost("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetTemplateFieldDtoV1>> AddTemplateFieldToTemplateAsync([FromRoute] Guid id)
        {
            Template template = await _templateService.GetTemplateByIdAsync(id);
            if(template == null)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GetTemplateDtoV1), StatusCodes.Status200OK)]
        public async Task<ActionResult<GetTemplateDtoV1>> GetTemplateByIdAsync([FromRoute] Guid id)
        {
            Template template = await _templateService.GetTemplateByIdAsync(id);
            if(template == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<GetTemplateDtoV1>(template));
        }
    }
}
