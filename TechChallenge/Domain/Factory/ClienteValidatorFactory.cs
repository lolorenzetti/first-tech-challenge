using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechChallenge.Domain._Shared;
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
