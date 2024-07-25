using FluentValidation;
using FluentValidation.Results;
using System.Text.RegularExpressions;
using TechChallenge.Domain.Entities;

namespace TechChallenge.Domain.Validators
{
    public class ClienteFluentValidation : AbstractValidator<Cliente>, _Shared.IValidator<Cliente>
    {
        public ClienteFluentValidation()
        {
            RuleFor(e => e.Cpf)
                .Matches(new Regex("^[0-9]{3}[0-9]{3}[0-9]{3}[0-9]{2}"))
                .WithMessage("CPF inválido");

            RuleFor(e => e.Nome)
                .MinimumLength(5)
                .WithMessage("Nome deve ter no mínimo 5 caracteres");

            RuleFor(e => e.Email)
                .EmailAddress()
                .WithMessage("Email inválido");
        }

        public void Validar(Cliente entity)
        {
            ValidationResult r = Validate(entity);

            foreach (var item in r.Errors)
            {
                entity.Notification.AddError(new Shared.NotificationErrorProp
                {
                    Context = nameof(Cliente),
                    Message = item.ErrorMessage
                });
            }
        }
    }
}
