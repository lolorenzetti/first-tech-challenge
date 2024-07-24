using Domain.Entities;
using FluentValidation;
using FluentValidation.Results;

namespace TechChallenge.Domain.Validators
{
    public class PedidoFluentValidation : AbstractValidator<Pedido>, _Shared.IValidator<Pedido>
    {
        public PedidoFluentValidation()
        {
            RuleFor(p => p.Itens)
                .NotEmpty()
                .WithMessage("Não é possível criar um pedido sem itens");
        }

        public void Validar(Pedido entity)
        {
            ValidationResult r = this.Validate(entity);

            foreach (var item in r.Errors)
            {
                entity.Notification.AddError(new Shared.NotificationErrorProp
                {
                    Context = nameof(Pedido),
                    Message = item.ErrorMessage
                });
            }
        }
    }
}
