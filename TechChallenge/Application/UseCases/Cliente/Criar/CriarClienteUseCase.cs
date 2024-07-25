using TechChallenge.Application.DTO;
using TechChallenge.Domain.Entities;
using TechChallenge.Domain.Ports;

namespace TechChallenge.Application.UseCases
{
    public class CriarClienteUseCase : ICriarClienteUseCase
    {
        private readonly IClienteRepository _clienteRepository;

        public CriarClienteUseCase(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<Cliente> Execute(CriarClienteDTO c)
        {
            var cliente = new Cliente(c.Nome, c.Email, c.Cpf);
            return await _clienteRepository.CadastrarCliente(cliente);
        }
    }
}
