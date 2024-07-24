using Domain.Entities;
using FluentValidation;
using FluentValidation.Results;

namespace TechChallenge.Domain.Validators
{
    public class PedidoItemFluentValidation : AbstractValidator<PedidoItem>, _Shared.IValidator<PedidoItem>
    {
        public PedidoItemFluentValidation()
        {
            RuleFor(p => p.ProdutoId)
                .NotEmpty()
                .WithMessage("É necessário informar um produto válido");

            RuleFor(p => p.Quantidade)
                .GreaterThanOrEqualTo(1)
                .WithMessage("Quantidade deve ser maior do que zero");

            RuleFor(p => p.Preco)
                .GreaterThan(0)
                .WithMessage("O preço deve ser maior que zero");

            RuleFor(p => p.Observacao)
                .MaximumLength(255)
                .WithMessage("Tamanho máximo para observaçao é de 255 caracteres");
        }

        public void Validar(PedidoItem entity)
        {
            ValidationResult r = this.Validate(entity);

            foreach (var item in r.Errors)
            {
                entity.Notification.AddError(new Shared.NotificationErrorProp
                {
                    Context = nameof(PedidoItem),
                    Message = item.ErrorMessage
                });
            }
        }
    }
}
