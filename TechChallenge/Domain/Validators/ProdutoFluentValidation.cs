using Domain.Entities;
using FluentValidation;
using FluentValidation.Results;

namespace TechChallenge.Domain.Validators
{
    public class ProdutoFluentValidation : AbstractValidator<Produto>, _Shared.IValidator<Produto>
    {
        public ProdutoFluentValidation()
        {
            RuleFor(p => p.Nome)
                .NotEmpty()
                .MinimumLength(3)
                .WithMessage("Nome do produto deve ter tamanho mínimo de 3 caracteres");

            RuleFor(p => p.Nome)
                .MaximumLength(100)
                .WithMessage("Nome deve ter no máximo 100 caracteres");

            RuleFor(p => p.Preco)
                .GreaterThan(0)
                .WithMessage("Preço deve ser maior que zero");

            RuleFor(p => p.Descricao)
                .MaximumLength(255)
                .WithMessage("Descrição deve ter no máximo 255 caracteres");

            RuleFor(p => p.Categoria)
                .IsInEnum()
                .WithMessage("Categoria inválida ou inexistente");
        }

        public void Validar(Produto entity)
        {
            ValidationResult r = this.Validate(entity);

            foreach (var item in r.Errors)
            {
                entity.Notification.AddError(new Shared.NotificationErrorProp
                {
                    Context = nameof(Produto),
                    Message = item.ErrorMessage
                });
            }
        }
    }
}