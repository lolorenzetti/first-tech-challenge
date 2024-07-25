using Domain.Entities;

namespace Domain.Ports
{
    public interface IPedidoRepository
    {
        public Task<Pedido?> ObterPorId(int id);
        public Task<List<Pedido>> ObterTodos();
        public Task<Pedido> Cria(Pedido pedido);
        public void Atualiza(Pedido pedido);
        public Task<List<Pedido>> ListaTodos();
    }
}
