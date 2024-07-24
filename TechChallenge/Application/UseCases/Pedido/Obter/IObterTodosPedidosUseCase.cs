using Domain.Entities;

namespace TechChallenge.Application.UseCases
{
    public interface IObterTodosPedidosUseCase
    {
        public Task<IEnumerable<Pedido>> Execute();
    }
}
