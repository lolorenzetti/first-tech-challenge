using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechChallenge.Application.UseCases.Obter
{
    public interface IObterClientePorCpfUseCase
    {
        public Task<Cliente?> Execute(string cpf);
    }
}
