using AutoMapper;
using GestorDocumental.Core.DTOs;
using GestorDocumental.Core.Entities;
using GestorDocumental.Core.Request;

namespace GestorDocumental.Infrastucture.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<TerceroRequest, Tercero>();
            CreateMap<Tercero, TerceroDto>();

            CreateMap<UsuarioRequest, Usuario>();
            CreateMap<Usuario, UsuarioDto>();

            CreateMap<CorrespondenciaRequest, Correspondencia>();
            CreateMap<Correspondencia, CorrespondenciaDto>();
        }
    }
}
