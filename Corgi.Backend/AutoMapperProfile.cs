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
            CreateMap<CharacterField, GetCharacterFieldDtoV1>()
                .ForMember(dest => dest.Origin, options => options.MapFrom(src => src.Origin.Id));
            CreateMap<TemplateField, CharacterField>()
                .ForMember(dest => dest.Id, options => options.Ignore())
                .ForMember(dest => dest.Origin, options => options.MapFrom(src => src));
            CreateMap<Template, GetTemplateDtoV1>();
            CreateMap<TemplateField, GetTemplateFieldDtoV1>();
            CreateMap<UpdateTemplateFieldDtoV1, TemplateField>();
        }
    }
}
