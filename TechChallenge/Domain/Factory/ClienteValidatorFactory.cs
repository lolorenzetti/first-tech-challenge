using TechChallenge.Domain._Shared;
using TechChallenge.Domain.Entities;
using TechChallenge.Domain.Validators;

namespace TechChallenge.Domain.Factory
{
    public static class ClienteValidatorFactory
    {
        public static IValidator<Cliente> Create()
        {
            return new ClienteFluentValidation();
        }
    }
}
