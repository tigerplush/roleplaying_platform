using AutoMapper;
using Corgi.Backend.Dtos.v1;
using Corgi.Backend.Models;

namespace Corgi.Backend
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, GetUserDtoV1>();
            CreateMap<Character, GetCharacterDtoV1>();
            CreateMap<Template, GetTemplateDtoV1>();
            CreateMap<TemplateField, GetTemplateFieldDtoV1>();
            CreateMap<UpdateTemplateFieldDtoV1, TemplateField>();
        }
    }
}
