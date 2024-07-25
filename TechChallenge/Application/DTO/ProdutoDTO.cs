using Domain.Enuns;

namespace TechChallenge.Application.DTO
{
    public record CriarProdutoDTO
    {
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public CategoriaProduto Categoria { get; set; }
        public decimal Preco { get; set; }
    }

    public record EditarProdutoDTO : CriarProdutoDTO
    {
        public int Id { get; set; }
    }

    public record VisualizarProdutoDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public CategoriaProduto Categoria { get; set; }
        public decimal Preco { get; set; }
    }

    public record ListaProdutosDTO
    {
        public List<VisualizarProdutoDTO> Produtos { get; set; }
    }

}
