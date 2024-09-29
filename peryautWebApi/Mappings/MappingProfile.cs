using AutoMapper;
using peryautWebApi.Dtos;
using peryautWebApi.Models;

namespace peryautWebApi.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Auto, AutoDto>()
            .ForMember(dest => dest.id_auto, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.nombredto, opt => opt.MapFrom(src => src.Nombre))
            .ForMember(dest => dest.aniodto, opt => opt.MapFrom(src => src.Año))
            .ForMember(dest => dest.colordto, opt => opt.MapFrom(src => src.Color))
            .ForMember(dest => dest.marcanamedto, opt => opt.MapFrom(src => src.IdMarcaNavigation.Marca1))
            .ReverseMap();

            CreateMap<Auto, PostAutoDto>()
            .ForMember(dest => dest.idpost, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.nombrepost, opt => opt.MapFrom(src => src.Nombre))
            .ForMember(dest => dest.aniopost, opt => opt.MapFrom(src => src.Año))
            .ForMember(dest => dest.colorpost, opt => opt.MapFrom(src => src.Color))
            .ForMember(dest => dest.activopost, opt => opt.MapFrom(src => src.Activo))
            .ForMember(dest => dest.id_marcapost, opt => opt.MapFrom(src => src.IdMarca))
            .ReverseMap();

            CreateMap<Marca, MarcaDto>()
            .ForMember(dest => dest.id_auto, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.marcadto, opt => opt.MapFrom(src => src.Marca1))
            .ReverseMap();

            CreateMap<Persona, PersonaDto>()
                .ForMember(dest => dest.id_persona, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.nombredto, opt => opt.MapFrom(src => src.Nombre))
                .ReverseMap();

            CreateMap<DueniosConAuto, DCADto>()
                .ForMember(dest => dest.id_dueniodca, opt => opt.MapFrom(src => src.IdDuenio))
                .ForMember(dest => dest.id_autodca, opt => opt.MapFrom(src => src.IdAuto))
                .ReverseMap();
        }
    }
}
