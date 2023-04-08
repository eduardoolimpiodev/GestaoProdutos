using AutoMapper;
using GP.WebApi.Dtos;
using GP.WebApi.Models;

namespace GP.WebApi.Helpers
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