using Domain.Entities;
using TechChallenge.Domain._Shared;
using TechChallenge.Domain.Validators;

namespace TechChallenge.Domain.Factory
{
    public class PedidoValidatorFactory
    {
        public static IValidator<Pedido> Create()
        {
            return new PedidoFluentValidation();
        }
    }
}
