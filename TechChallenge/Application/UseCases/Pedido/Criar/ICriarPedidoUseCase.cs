using Domain.Entities;
using TechChallenge.Application.DTO;

namespace TechChallenge.Application.UseCases
{
    public interface ICriarPedidoUseCase
    {
        public Task<Pedido> Execute(CriarPedidoDTO createPedidoDTO);
    }
}
