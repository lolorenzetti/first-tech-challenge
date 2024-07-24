using Domain.Entities;
using Domain.Enuns;

namespace TechChallenge.Application.UseCases
{
    public interface IObterProdutoUseCase
    {
        public Task<Produto?> ObterPorId(int id);
        public Task<IEnumerable<Produto?>> ObterPorCategoria(CategoriaProduto categoria);
    }
}
