﻿using Corgi.Backend.Models;

namespace Corgi.Backend.Services.TemplateService
{
    public interface ITemplateService
    {
        public Task<bool> DeleteTemplateAsync(Guid id);
        public Task<Template> GetTemplateByIdAsync(Guid id);
        public Task<Template> CreateNewTemplateAsync(string name);
        public Task<Template[]> GetAllTemplatesAsync();
        public Task<TemplateField> AddTemplateFieldToTemplateAsync(Template template);
        public Task<TemplateField> UpdateTemplateFieldAsync(TemplateField field, TemplateField update);
        public Task DeleteTemplateFieldAsync(Template template, TemplateField field);
    }
}
