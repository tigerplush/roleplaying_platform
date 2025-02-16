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
        }
    }
}
