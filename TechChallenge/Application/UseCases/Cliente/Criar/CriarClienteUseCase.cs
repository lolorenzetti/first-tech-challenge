using Domain.Entities;
using Domain.Ports;
using TechChallenge.Application.DTO;

namespace TechChallenge.Application.UseCases.Criar
{
    public class CriarClienteUseCase : ICriarClienteUseCase
    {
        private readonly IClienteRepository _clienteRepository;

        public CriarClienteUseCase(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<Cliente> Execute(CriarClienteDTO criarClienteDTO)
        {
            var cliente = new Cliente(criarClienteDTO.Nome, criarClienteDTO.Email, criarClienteDTO.Cpf);
            return await _clienteRepository.CadastrarCliente(cliente);
        }
    }
}
