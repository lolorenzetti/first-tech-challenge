using Domain.Entities;
using TechChallenge.Application.DTO;

namespace TechChallenge.Application.UseCases
{
    public interface ICriarClienteUseCase
    {
        public Task<Cliente> Execute(CriarClienteDTO criarClienteDTO);
    }
}