using Domain.Entities;
using TechChallenge.Domain._Shared;
using TechChallenge.Domain.Validators;

namespace TechChallenge.Domain.Factory
{
    internal class PedidoItemValidatorFactory
    {
        public static IValidator<PedidoItem> Create()
        {
            return new PedidoItemFluentValidation();
        }
    }
}
