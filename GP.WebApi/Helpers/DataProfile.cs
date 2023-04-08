using AutoMapper;
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
        }
    }
}