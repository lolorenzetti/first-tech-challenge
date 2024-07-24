using Domain.Entities;
using Domain.Enuns;
using Domain.Ports;
using TechChallenge.Application.DTO;
using TechChallenge.Application.UseCases;
using TechChallenge.Application.UseCases.Criar;

namespace TechChallenge.Controller
{
    public class ProdutoService : IProdutoService
    {
        private IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<Produto> Criar(CriarProdutoDTO produtoDTO)
        {
            var useCase = new CriarProdutoUseCase(_produtoRepository);
            return await useCase.Execute(produtoDTO);
        }

        public async Task Editar(EditarProdutoDTO editarProdutoDTO)
        {
            var useCase = new EditarProdutoUseCase(_produtoRepository);
            await useCase.Execute(editarProdutoDTO);
        }

        public async Task<IEnumerable<Produto?>> ObterPorCategoria(int categoria)
        {
            var useCase = new ObterProdutoUseCase(_produtoRepository);

            CategoriaProduto c;

            if (!Enum.TryParse<CategoriaProduto>(categoria.ToString(), out c))
            {
                throw new Exception("Categoria informada é inválida");
            }

            return await useCase.ObterPorCategoria(c);
        }

        public async Task<Produto?> ObterPorId(int id)
        {
            var useCase = new ObterProdutoUseCase(_produtoRepository);
            return await useCase.ObterPorId(id);
        }

        public async Task Remover(int id)
        {
            var useCase = new RemoverProdutoUseCase(_produtoRepository);
            await useCase.Execute(id);
        }
    }
}
