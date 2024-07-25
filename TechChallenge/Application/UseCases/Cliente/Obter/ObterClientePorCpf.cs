using TechChallenge.Application.UseCase;
using TechChallenge.Domain.Entities;
using TechChallenge.Domain.Ports;

namespace TechChallenge.Application.UseCases
{
    public class ObterClientePorCpfUseCase : IObterClientePorCpfUseCase
    {
        private IClienteRepository _clienteRepository;

        public ObterClientePorCpfUseCase(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<Cliente?> Execute(string cpf)
        {
            return await _clienteRepository.BuscarPorCpf(cpf);
        }
    }
}
