using AutoMapper;
using GP.WebApi.Models;
using GP.WebApi.V2.Dtos;
using GP.WebApi.V2.Models;




namespace GP.WebApi.V2.Profiles
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

        }
    }
}