using Domain.Entities;
using TechChallenge.Application.DTO;

namespace TechChallenge.Controller
{
    public interface IPedidoService
    {
        public Task<Pedido> Criar(CriarPedidoDTO criarPedidoDTO);
        public Task<IEnumerable<Pedido?>> ObterTodos();
        public Task RealizarChecktou(int id);
    }
}
