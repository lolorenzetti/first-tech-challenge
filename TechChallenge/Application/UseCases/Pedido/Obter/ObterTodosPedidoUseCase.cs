using Domain.Entities;
using Domain.Ports;

namespace TechChallenge.Application.UseCases
{
    public class ObterTodosPedidoUseCase : IObterTodosPedidosUseCase
    {
        private IPedidoRepository _pedidoRepository;

        public ObterTodosPedidoUseCase(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public async Task<IEnumerable<Pedido>> Execute()
        {
            return await _pedidoRepository.ListaTodos();
        }
    }
}
