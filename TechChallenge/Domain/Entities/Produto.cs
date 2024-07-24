using Domain.Enuns;
using TechChallenge.Domain._Shared;
using TechChallenge.Domain.Factory;
using TechChallenge.Domain.Shared;

namespace Domain.Entities
{
    public class Produto : Entity
    {
        public Produto(string nome, string descricao, CategoriaProduto categoria, decimal preco)
        {
            Nome = nome;
            Descricao = descricao;
            Categoria = categoria;
            Preco = preco;
            Validate();
        }

        public string Nome { get; private set; } = string.Empty;
        public string Descricao { get; private set; } = string.Empty;
        public CategoriaProduto Categoria { get; private set; }
        public decimal Preco { get; private set; }

        public void Atualiza(string? nome, string? descricao, CategoriaProduto? categoria, decimal? preco)
        {
            this.Nome = string.IsNullOrEmpty(nome) ? this.Nome : nome;
            this.Descricao = string.IsNullOrEmpty(descricao) ? this.Descricao : descricao;

            if (categoria != null && categoria != this.Categoria)
            {
                this.Categoria = (CategoriaProduto)categoria;
            }

            if (preco != null && preco != this.Preco)
            {
                this.Preco = (decimal)preco;
            }

            Validate();
        }

        public override void Validate()
        {
            ProdutoValidatorFactory.Create().Validar(this);
            if (this.Notification.HasErrors())
                throw new NotificationError(this.Notification.GetErrors());
        }
    }
}
