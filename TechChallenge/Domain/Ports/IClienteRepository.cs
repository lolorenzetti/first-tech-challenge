﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Ports
{
    public interface IClienteRepository
    {
        Task<Cliente> CadastrarCliente(Cliente cliente);
        Task<Cliente?> BuscarPorCpf(string cpf);
        Task<Cliente?> BuscarPorId(int id);
    }
}
