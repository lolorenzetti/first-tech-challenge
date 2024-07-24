using Domain.Ports;
using TechChallenge.Application.DTO;
using TechChallenge.Application.UseCases.Editar;

namespace TechChallenge.Application.UseCases
{
    public class EditarProdutoUseCase : IEditarProdutoUseCase
    {
        private IProdutoRepository _produtoRepository;

        public EditarProdutoUseCase(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task Execute(EditarProdutoDTO updateProdutoDTO)
        {
            var produto = await _produtoRepository.ObterPorId(updateProdutoDTO.Id);

            if (produto == null)
            {
                throw new Exception("Produto não encontrado!");
            }

            produto.Atualiza(
                updateProdutoDTO.Nome,
                updateProdutoDTO.Descricao,
                updateProdutoDTO.Categoria,
                updateProdutoDTO.Preco
             );

            await _produtoRepository.Atualizar(produto);
        }
    }
}
