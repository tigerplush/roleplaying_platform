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

        public TemplatesController(ITemplateService templateService)
        {
            _templateService = templateService;
        }

        [HttpPost]
        public async Task<ActionResult<GetTemplateDtoV1>> CreateNewTemplateAsync()
        {
            return Ok();
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
    }
}
