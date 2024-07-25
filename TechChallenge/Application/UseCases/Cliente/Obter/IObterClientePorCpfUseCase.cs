using TechChallenge.Domain.Entities;

namespace TechChallenge.Application.UseCase
{
    public interface IObterClientePorCpfUseCase
    {
        public Task<Cliente?> Execute(string cpf);
    }
}
