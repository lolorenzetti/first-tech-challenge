using Domain.Entities;
using TechChallenge.Application.DTO;

namespace TechChallenge.Controller
{
    public interface IClienteService
    {
        Task<Cliente> Criar(CriarClienteDTO clienteInput);
        Task<Cliente?> ObterPorCPF(string cpf);
    }
}