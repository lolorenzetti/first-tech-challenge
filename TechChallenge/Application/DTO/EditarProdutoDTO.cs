﻿using Domain.Enuns;

namespace TechChallenge.Application.DTO
{
    public record EditarProdutoDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public CategoriaProduto Categoria { get; set; }
        public decimal Preco { get; set; }
    }
}
