using AutoMapper;
using krugerEvaluacion.Core.DTOs;
using krugerEvaluacion.Core.Entities;

namespace krugerEvaluacion.Infrastructure.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Propietario, PropietarioDto>();
            CreateMap<PropietarioDto, Propietario>();

            CreateMap<Security, SecurityDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
