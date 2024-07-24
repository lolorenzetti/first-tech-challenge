using Application.Models.ViewModel;
using AutoMapper;
using Domain.Entities;

namespace TechChallenge.Application.Mappings
{
    public class ProdutoMapper : Profile
    {
        public ProdutoMapper()
        {
            CreateMap<Produto, ProdutoViewModel>();
            CreateMap<IEnumerable<Produto>, ListProdutoViewModel>(); // NOTA: Porque não IEnumerable? Avaliar.
        }
    }
}
