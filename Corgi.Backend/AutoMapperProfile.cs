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
            CreateMap<Character, GetCharacterDtoV1>()
                .ForMember(dest => dest.Template, options => options.MapFrom(src => src.Template.Id));
            //@todo exchange
            CreateMap<CharacterField, GetTemplateFieldDtoV1>();
            CreateMap<TemplateField, CharacterField>()
                .ForMember(dest => dest.Id, options => options.Ignore());
            CreateMap<Template, GetTemplateDtoV1>();
            CreateMap<TemplateField, GetTemplateFieldDtoV1>();
            CreateMap<UpdateTemplateFieldDtoV1, TemplateField>();
        }
    }
}
