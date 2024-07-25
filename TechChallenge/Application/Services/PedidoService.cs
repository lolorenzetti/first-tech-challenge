using Domain.Entities;
using Domain.Ports;
using TechChallenge.Application.DTO;
using TechChallenge.Application.UseCases;
using TechChallenge.Application.UseCases.Obter;

namespace TechChallenge.Application.Services
{
    public class PedidoService : IPedidoService
    {
        private IPedidoRepository _pedidoRepository;
        private IProdutoRepository _produtoRepository;
        private IClienteRepository _clienteRepository;

        public PedidoService(
            IPedidoRepository pedidoRepository,
            IProdutoRepository produtoRepository,
            IClienteRepository clienteRepository)
        {
            _pedidoRepository = pedidoRepository;
            _produtoRepository = produtoRepository;
            _clienteRepository = clienteRepository;
        }

        public async Task<Pedido> Criar(CriarPedidoDTO criarPedidoDTO)
        {
            var obterClienteUseCase = new ObterClientePorCpfUseCase(_clienteRepository);
            var obterProdutoUseCase = new ObterProdutoUseCase(_produtoRepository);
            var useCase = new CriarPedidoUseCase(_pedidoRepository, obterProdutoUseCase, obterClienteUseCase);
            return await useCase.Execute(criarPedidoDTO);
        }

        public async Task<IEnumerable<Pedido?>> ObterTodos()
        {
            var useCase = new ObterTodosPedidoUseCase(_pedidoRepository);
            return await useCase.Execute();
        }

        public async Task RealizarChecktou(int id)
        {
            var useCase = new CheckoutPedidoUseCase(_pedidoRepository);
            await useCase.Execute(id);
        }
    }
}
