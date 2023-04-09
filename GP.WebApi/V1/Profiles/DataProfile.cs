using AutoMapper;
using GP.WebApi.V1.Dtos;
using GP.WebApi.Models;
using GP.WebApi.V1.Models;

namespace GP.WebApi.V1.Profiles
{
    public class DataProfile : Profile
    {
        public DataProfile()
        {
            CreateMap<Produto, ProdutoDto>()
                .ForMember(
                    dest => dest.Nome,
                    opt => opt.MapFrom(src => src.Nome)
                );

            CreateMap<ProdutoDto, Produto>();
            CreateMap<Produto, ProdutoRegistrarDto>().ReverseMap();

            CreateMap<Representante, RepresentanteDto>()
                .ForMember(
                    dest => dest.Nome,
                    opt => opt.MapFrom(src => src.Nome)  
                );

            CreateMap<RepresentanteDto, Representante>();
            CreateMap<Representante, RepresentanteRegistrarDto>().ReverseMap();   
        }
    }
}