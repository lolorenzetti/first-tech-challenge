using TechChallenge.Application.DTO;

namespace TechChallenge.Application.Controllers.Produto
{
    public interface IProdutoController
    {
        public Task<VisualizarProdutoDTO> Criar(CriarProdutoDTO produtoDTO);
        public Task<VisualizarProdutoDTO?> ObterPorId(int id);
        public Task<ListaProdutosDTO> ObterPorCategoria(int categoria);
        public Task Editar(EditarProdutoDTO editarProdutoDTO);
        public Task Remover(int id);
    }
}
