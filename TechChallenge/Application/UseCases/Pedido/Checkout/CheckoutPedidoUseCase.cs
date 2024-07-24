using Domain.Ports;

namespace TechChallenge.Application.UseCases
{
    public class CheckoutPedidoUseCase : ICheckoutPedidoUseCase
    {
        private IPedidoRepository _pedidoRepository;

        public CheckoutPedidoUseCase(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public async Task Execute(int id)
        {
            var pedido = await _pedidoRepository.ObterPorId(id);

            if (pedido == null)
                throw new Exception($"Pedido com identificador {id} não encontrado.");

            pedido.ReceberPedido();

            _pedidoRepository.Atualiza(pedido);
        }
    }
}
