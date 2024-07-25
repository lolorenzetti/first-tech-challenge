using Domain.Entities;
using TechChallenge.Application.DTO;

namespace TechChallenge.Application.Services
{
    public interface IProdutoService
    {
        public Task<Produto> Criar(CriarProdutoDTO produtoDTO);
        public Task<Produto?> ObterPorId(int id);
        public Task<IEnumerable<Produto?>> ObterPorCategoria(int categoria);
        public Task Editar(EditarProdutoDTO editarProdutoDTO);
        public Task Remover(int id);
    }
}
