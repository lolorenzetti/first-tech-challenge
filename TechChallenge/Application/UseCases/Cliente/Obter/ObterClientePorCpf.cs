using Application.Models.ViewModel;
using Domain.Entities;
using Domain.Ports;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechChallenge.Application.Notifications;

namespace TechChallenge.Application.UseCases.Obter
{
    public class ObterClientePorCpfUseCase : IObterClientePorCpfUseCase
    {
        private IClienteRepository _clienteRepository;

        public ObterClientePorCpfUseCase(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<Cliente?> Execute(string cpf)
        {
            return await _clienteRepository.BuscarPorCpf(cpf);
        }
    }
}
