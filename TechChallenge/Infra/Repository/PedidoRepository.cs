using Domain.Entities;
using Domain.Ports;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repository
{
    public class PedidoRepository : IPedidoRepository
    {
        public PedidoRepository(DatabaseContext databaseContext)
        {
            _context = databaseContext;
        }

        public DatabaseContext _context { get; set; }

        public void Atualiza(Pedido pedido)
        {
            _context.Pedidos.Update(pedido);
            _context.SaveChanges();
        }

        public async Task<Pedido> Cria(Pedido pedido)
        {
            var p = await _context.Pedidos.AddAsync(pedido);
            await _context.PedidoItems.AddRangeAsync(pedido.Itens);

            _context.SaveChanges();

            return p.Entity;
        }

        public async Task<List<Pedido>> ListaTodos()
        {
            return await _context.Pedidos.ToListAsync();
        }

        public async Task<Pedido?> ObterPorId(int id)
        {
            return await _context.Pedidos
                .Where(p => p.Id == id)
                .Include(p => p.Itens)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Pedido>> ObterTodos()
        {
            return await _context.Pedidos
                .Include(p => p.Itens).ToListAsync();
        }
    }
}
