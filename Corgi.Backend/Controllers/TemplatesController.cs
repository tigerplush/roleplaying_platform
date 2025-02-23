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
        [ProducesResponseType(typeof(TemplateResponseDtoV1), StatusCodes.Status200OK)]
        public async Task<ActionResult<TemplateResponseDtoV1>> GetAllTemplatesAsync()
        {
            Template[] templates = await _templateService.GetAllTemplatesAsync();
            return Ok(new TemplateResponseDtoV1()
            {
                Templates = _mapper.Map<GetTemplateDtoV1[]>(templates)
            });
        }

        [HttpPost]
        [ProducesResponseType(typeof(GetTemplateDtoV1), StatusCodes.Status201Created)]
        public async Task<ActionResult<GetTemplateDtoV1>> CreateNewTemplateAsync(AddTemplateDtoV1 newTemplate)
        {
            Template template = await _templateService.CreateNewTemplateAsync(newTemplate.Name);
            return Created($"{Url.Action()}/{template.Id}", _mapper.Map<GetTemplateDtoV1>(template));
        }

        [HttpDelete("{templateId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteTemplateAsync([FromRoute] Guid templateId)
        {
            bool success = await _templateService.DeleteTemplateAsync(templateId);
            if(!success)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPost("{templateId}/fields")]
        [ProducesResponseType(typeof(GetTemplateFieldDtoV1), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetTemplateFieldDtoV1>> AddTemplateFieldToTemplateAsync([FromRoute] Guid templateId, AddTemplateFieldDtoV1 newField)
        {
            Template template = await _templateService.GetTemplateByIdAsync(templateId);
            if(template == null)
            {
                return NotFound();
            }
            TemplateField field = await _templateService.AddTemplateFieldToTemplateAsync(template);
            return Created($"{Url.Action()}/{field.Id}", _mapper.Map<GetTemplateFieldDtoV1>(field));
        }

        [HttpGet("{templateId}")]
        [ProducesResponseType(typeof(GetTemplateDtoV1), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetTemplateDtoV1>> GetTemplateByIdAsync([FromRoute] Guid templateId)
        {
            Template template = await _templateService.GetTemplateByIdAsync(templateId);
            if(template == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<GetTemplateDtoV1>(template));
        }

        [HttpPut("{templateId}/fields/{fieldId}")]
        [ProducesResponseType(typeof(GetTemplateFieldDtoV1), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetTemplateFieldDtoV1>> UpdateTemplateByIdAsync([FromRoute] Guid templateId, [FromRoute] Guid fieldId, UpdateTemplateFieldDtoV1 update)
        {
            if(fieldId != update.Id)
            {
                return BadRequest();
            }
            Template template = await _templateService.GetTemplateByIdAsync(templateId);
            if (template == null)
            {
                return NotFound();
            }
            TemplateField field = template.Fields.FirstOrDefault(field => field.Id == fieldId);
            if(field == null)
            {
                return NotFound();
            }
            field = await _templateService.UpdateTemplateFieldAsync(field, _mapper.Map<TemplateField>(update));
            return Ok(_mapper.Map<GetTemplateFieldDtoV1>(field));
        }

        [HttpDelete("{templateId}/fields/{fieldId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteTemplateFieldByIdAsync([FromRoute] Guid templateId, [FromRoute] Guid fieldId)
        {
            Template template = await _templateService.GetTemplateByIdAsync(templateId);
            if (template == null)
            {
                return NotFound();
            }
            TemplateField field = template.Fields.FirstOrDefault(field => field.Id == fieldId);
            if (field == null)
            {
                return NotFound();
            }
            await _templateService.DeleteTemplateFieldAsync(template, field);
            return NoContent();
        }
    }
}
