using TechChallenge.Application.DTO;

namespace TechChallenge.Application.Controllers.Cliente
{
    public interface IClienteController
    {
        Task<VisualizarClienteDTO> Criar(CriarClienteDTO clienteInput);
        Task<VisualizarClienteDTO?> ObterPorCPF(string cpf);
    }
}