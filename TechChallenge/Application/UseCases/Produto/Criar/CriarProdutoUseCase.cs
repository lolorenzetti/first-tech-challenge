using Domain.Entities;
using Domain.Ports;
using TechChallenge.Application.DTO;

namespace TechChallenge.Application.UseCases.Criar
{
    public class CriarProdutoUseCase : ICriarProdutoUseCase
    {
        private IProdutoRepository _produtoRepository;

        public CriarProdutoUseCase(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<Produto> Execute(CriarProdutoDTO produtoDTO)
        {
            var produto = new Produto(
                produtoDTO.Nome,
                produtoDTO.Descricao,
                produtoDTO.Categoria,
                produtoDTO.Preco
             );

            return await _produtoRepository.Adicionar(produto);
        }
    }
}
