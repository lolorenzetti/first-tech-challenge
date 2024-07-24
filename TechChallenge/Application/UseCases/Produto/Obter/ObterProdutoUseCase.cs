using Domain.Entities;
using Domain.Enuns;
using Domain.Ports;

namespace TechChallenge.Application.UseCases
{
    public class ObterProdutoUseCase : IObterProdutoUseCase
    {
        private IProdutoRepository _produtoRepository;

        public ObterProdutoUseCase(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<IEnumerable<Produto?>> ObterPorCategoria(CategoriaProduto categoria)
        {
            return await _produtoRepository.ObterPorCategoria(categoria);
        }

        public async Task<Produto?> ObterPorId(int id)
        {
            return await _produtoRepository.ObterPorId(id);
        }
    }
}
