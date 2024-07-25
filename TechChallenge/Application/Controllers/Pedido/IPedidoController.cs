using TechChallenge.Application.DTO;

namespace TechChallenge.Application.Controllers.Pedido
{
    public interface IPedidoController
    {
        public Task<VisualizarPedidoDTO> Criar(CriarPedidoDTO criarPedidoDTO);
        public Task<ListaPedidosDTO> ObterTodos();
        public Task RealizarChecktou(int id);
    }
}
