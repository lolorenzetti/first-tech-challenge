using Domain.Entities;
using Domain.Ports;
using TechChallenge.Application.DTO;
using TechChallenge.Application.UseCases.Obter;

namespace TechChallenge.Application.UseCases
{
    public class CriarPedidoUseCase : ICriarPedidoUseCase
    {
        private IPedidoRepository _pedidoRepository;
        private IObterProdutoUseCase _produtoUseCase;
        private IObterClientePorCpfUseCase _clienteUseCase;

        public CriarPedidoUseCase(
            IPedidoRepository pedidoRepository,
            IObterProdutoUseCase produtoUseCase,
            IObterClientePorCpfUseCase clienteUseCase)
        {
            _pedidoRepository = pedidoRepository;
            _produtoUseCase = produtoUseCase;
            _clienteUseCase = clienteUseCase;
        }

        public async Task<Pedido> Execute(CriarPedidoDTO request)
        {
            Pedido pedido = new();

            foreach (var i in request.Itens)
            {
                var produto = await _produtoUseCase.ObterPorId(i.Id);

                if (produto is null)
                    throw new Exception($"Produto com identificador '{i.Id}' não encontrado");

                var item = new PedidoItem(produto.Id, i.Quantidade, produto.Preco, i.Observacao!);
                pedido.AdicionarItem(item);
            }

            if (!string.IsNullOrEmpty(request.ClienteCpf))
            {
                var cliente = await _clienteUseCase.Execute(request.ClienteCpf);

                if (cliente is null)
                    throw new Exception($"Cliente com cpf: '{request.ClienteCpf}' não encontrado");

                pedido.ReferenciarCliente(cliente.Id);
            }

            return await _pedidoRepository.Cria(pedido);
        }
    }
}
