using Domain.Entities;
using Domain.Ports;
using TechChallenge.Application.DTO;
using TechChallenge.Application.UseCases.Criar;
using TechChallenge.Application.UseCases.Obter;

namespace TechChallenge.Application.Services
{
    public class ClienteService : IClienteService
    {
        private IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<Cliente> Criar(CriarClienteDTO criarClienteDTO)
        {
            CriarClienteUseCase useCase = new(_clienteRepository);
            return await useCase.Execute(criarClienteDTO);
        }

        public async Task<Cliente?> ObterPorCPF(string cpf)
        {
            ObterClientePorCpfUseCase useCase = new(_clienteRepository);
            return await useCase.Execute(cpf);
        }
    }
}
