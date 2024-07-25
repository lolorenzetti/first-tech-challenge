using AutoMapper;
using TechChallenge.Application.DTO;
using TechChallenge.Application.UseCases;
using TechChallenge.Domain.Ports;

namespace TechChallenge.Application.Controllers.Cliente
{
    public class ClienteController : IClienteController
    {
        private IClienteRepository _clienteRepository;
        private IMapper _mapper;

        public ClienteController(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public async Task<VisualizarClienteDTO> Criar(CriarClienteDTO criarClienteDTO)
        {
            CriarClienteUseCase useCase = new(_clienteRepository);
            var result = await useCase.Execute(criarClienteDTO);
            return _mapper.Map<VisualizarClienteDTO>(result);
        }

        public async Task<VisualizarClienteDTO?> ObterPorCPF(string cpf)
        {
            ObterClientePorCpfUseCase useCase = new(_clienteRepository);
            var result = await useCase.Execute(cpf);
            return _mapper.Map<VisualizarClienteDTO>(result);
        }
    }
}
