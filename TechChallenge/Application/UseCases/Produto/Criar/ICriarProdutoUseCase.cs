using Domain.Entities;
using TechChallenge.Application.DTO;

namespace TechChallenge.Application.UseCases
{
    public interface ICriarProdutoUseCase
    {
        public Task<Produto> Execute(CriarProdutoDTO produtoDTO);
    }
}
