using Domain.Entities;
using Domain.Enuns;

namespace TechChallenge.Application.DTO
{
    public record CriarPedidoDTO
    {
        public string? ClienteCpf { get; set; }
        public List<PedidoItemDTO> Itens { get; set; }
    }

    public record PedidoItemDTO
    {
        public int Id { get; set; }
        public int Quantidade { get; set; }
        public string? Observacao { get; set; } = string.Empty;
    }

    public record VisualizarPedidoDTO
    {
        public int Id { get; set; }
        public string? ClienteCPF { get; set; }
        public StatusPedido Status { get; set; }
        public List<PedidoItem> Itens { get; set; }
    }

    public record ListaPedidosDTO
    {
        public List<VisualizarPedidoDTO> Pedidos { get; set; }
    }
}
