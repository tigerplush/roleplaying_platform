using Corgi.Backend.Models;

namespace Corgi.Backend.Services.TemplateService
{
    public interface ITemplateService
    {
        public Task<bool> DeleteTemplateAsync(Guid id);
        public Task<Template> GetTemplateByIdAsync(Guid id);
    }
}
