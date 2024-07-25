using TechChallenge.Application.DTO;
using TechChallenge.Domain.Entities;

namespace TechChallenge.Application.UseCases
{
    public interface ICriarClienteUseCase
    {
        public Task<Cliente> Execute(CriarClienteDTO criarClienteDTO);
    }
}