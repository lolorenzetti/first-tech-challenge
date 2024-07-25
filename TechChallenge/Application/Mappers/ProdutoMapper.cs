using AutoMapper;
using Domain.Entities;
using TechChallenge.Application.DTO;

namespace TechChallenge.Application.Mappings
{
    public class ProdutoMapper : Profile
    {
        public ProdutoMapper()
        {
            CreateMap<Produto, VisualizarProdutoDTO>();
            CreateMap<IEnumerable<Produto>, ListaProdutosDTO>(); // NOTA: Porque não IEnumerable? Avaliar.
        }
    }
}
