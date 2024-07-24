using Domain.Ports;

namespace TechChallenge.Application.UseCases
{
    public class RemoverProdutoUseCase : IRemoverProdutoUseCase
    {
        private IProdutoRepository _produtoRepository;

        public RemoverProdutoUseCase(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task Execute(int id)
        {
            await _produtoRepository.Deletar(id);
        }
    }
}
