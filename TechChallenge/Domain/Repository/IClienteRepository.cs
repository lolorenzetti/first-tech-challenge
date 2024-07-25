using TechChallenge.Domain.Entities;

namespace TechChallenge.Domain.Ports
{
    public interface IClienteRepository
    {
        Task<Cliente> CadastrarCliente(Cliente cliente);
        Task<Cliente?> BuscarPorCpf(string cpf);
        Task<Cliente?> BuscarPorId(int id);
    }
}
