using AutoMapper;
using Domain.Ports;
using TechChallenge.Application.DTO;
using TechChallenge.Application.UseCases;
using TechChallenge.Domain.Ports;

namespace TechChallenge.Application.Controllers.Pedido
{
    public class PedidoController : IPedidoController
    {
        private IPedidoRepository _pedidoRepository;
        private IProdutoRepository _produtoRepository;
        private IClienteRepository _clienteRepository;
        private IMapper _mapper;

        public PedidoController(
            IPedidoRepository pedidoRepository,
            IProdutoRepository produtoRepository,
            IClienteRepository clienteRepository,
            IMapper mapper)
        {
            _pedidoRepository = pedidoRepository;
            _produtoRepository = produtoRepository;
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public async Task<VisualizarPedidoDTO> Criar(CriarPedidoDTO criarPedidoDTO)
        {
            var obterClienteUseCase = new ObterClientePorCpfUseCase(_clienteRepository);
            var obterProdutoUseCase = new ObterProdutoUseCase(_produtoRepository);
            var useCase = new CriarPedidoUseCase(_pedidoRepository, obterProdutoUseCase, obterClienteUseCase);
            var result = await useCase.Execute(criarPedidoDTO);
            return _mapper.Map<VisualizarPedidoDTO>(result);
        }

        public async Task<ListaPedidosDTO> ObterTodos()
        {
            var useCase = new ObterTodosPedidoUseCase(_pedidoRepository);
            var result = await useCase.Execute();
            return _mapper.Map<ListaPedidosDTO>(result);
        }

        public async Task RealizarChecktou(int id)
        {
            var useCase = new CheckoutPedidoUseCase(_pedidoRepository);
            await useCase.Execute(id);
        }
    }
}
