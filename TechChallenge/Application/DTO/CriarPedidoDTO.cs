namespace TechChallenge.Application.DTO
{
    public class CriarPedidoDTO
    {
        public CriarPedidoDTO(List<Item> itens)
        {
            Itens = itens;
        }

        public string? ClienteCpf { get; set; }
        public List<Item> Itens { get; set; }
    }

    public record Item
    {
        public int Id { get; set; }
        public int Quantidade { get; set; }
        public string? Observacao { get; set; } = string.Empty;
    }
}
