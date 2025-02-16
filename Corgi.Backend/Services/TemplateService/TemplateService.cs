using Corgi.Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Corgi.Backend.Services.TemplateService
{
    public class TemplateService : ITemplateService
    {
        private readonly DatabaseContext _context;

        public TemplateService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<bool> DeleteTemplateAsync(Guid id)
        {
            Template template = await _context
                .Templates
                .FirstOrDefaultAsync(template => template.Id == id);

            if(template != null)
            {
                _context.Remove(template);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<Template> GetTemplateByIdAsync(Guid id)
        {
            return await _context.Templates.FirstOrDefaultAsync(template => template.Id == id);
        }

        public async Task<Template> CreateNewTemplateAsync(string name)
        {
            Template template = new()
            {
                Name = name
            };
            await _context.Templates.AddAsync(template);
            await _context.SaveChangesAsync();
            return template;
        }


        public async Task<Template[]> GetAllTemplatesAsync()
        {
            return await _context.Templates.ToArrayAsync();
        }
    }
}
