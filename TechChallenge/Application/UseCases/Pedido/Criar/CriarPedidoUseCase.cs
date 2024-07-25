using Domain.Entities;
using Domain.Ports;
using TechChallenge.Application.DTO;
using TechChallenge.Application.UseCase;

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

        public async Task<Pedido> Execute(CriarPedidoDTO p)
        {
            Pedido pedido = new();

            foreach (var i in p.Itens)
            {
                var produto = await _produtoUseCase.ObterPorId(i.Id);

                if (produto is null)
                    throw new Exception($"Produto com identificador '{i.Id}' não encontrado");

                var item = new PedidoItem(produto.Id, i.Quantidade, produto.Preco, i.Observacao!);
                pedido.AdicionarItem(item);
            }

            if (!string.IsNullOrEmpty(p.ClienteCpf))
            {
                var cliente = await _clienteUseCase.Execute(p.ClienteCpf);

                if (cliente is null)
                    throw new Exception($"Cliente com cpf: '{p.ClienteCpf}' não encontrado");

                pedido.ReferenciarCliente(cliente.Id);
            }

            return await _pedidoRepository.Cria(pedido);
        }
    }
}
