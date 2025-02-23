using AutoMapper;
using Corgi.Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Corgi.Backend.Services.TemplateService
{
    public class TemplateService : ITemplateService
    {
        private readonly DatabaseContext _context;

        public TemplateService(
            DatabaseContext context
            , IMapper mapper
            )
        {
            _context = context;
        }

        public async Task<bool> DeleteTemplateAsync(Guid id)
        {
            Template template = await _context
                .Templates
                .Where(template => template.Id == id)
                .Include(template => template.Fields)
                .FirstOrDefaultAsync();

            if(template != null)
            {
                _context.TemplateFields.RemoveRange(template.Fields);
                _context.Templates.Remove(template);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<Template> GetTemplateByIdAsync(Guid id)
        {
            return await _context
                .Templates
                .Where(template => template.Id == id)
                .Include(template => template.Fields.OrderBy(field => field.CreatedAt))
                .FirstOrDefaultAsync();
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

        public async Task<TemplateField> AddTemplateFieldToTemplateAsync(Template template)
        {
            TemplateField field = new()
            {
                Owner = template
            };
            template.Fields.Add(field);
            await _context.SaveChangesAsync();
            return field;
        }

        public async Task<TemplateField> UpdateTemplateFieldAsync(TemplateField field, TemplateField update)
        {
            field.Name = update.Name;
            field.FieldType = update.FieldType;
            field.Value = update.Value;
            field.IsVisible = update.IsVisible;
            await _context.SaveChangesAsync();
            return field;
        }

        public async Task DeleteTemplateFieldAsync(Template template, TemplateField field)
        {
            template.Fields.Remove(field);
            _context.TemplateFields.Remove(field);
            await _context.SaveChangesAsync();
        }
    }
}
