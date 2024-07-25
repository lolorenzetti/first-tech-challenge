﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechChallenge.Domain.Entities;
using TechChallenge.Domain.Ports;

namespace Infra.Data.Repository
{
    public class ClienteRepository : IClienteRepository
    {

        private DatabaseContext _context;

        public ClienteRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Cliente?> BuscarPorCpf(string cpf)
        {
            return await _context.Clientes.FirstOrDefaultAsync(c => c.Cpf == cpf);
        }

        public async Task<Cliente?> BuscarPorId(int id)
        {
            return await _context.Clientes.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Cliente> CadastrarCliente(Cliente cliente)
        {
            var entity = await _context.Clientes.AddAsync(cliente);
            _context.SaveChanges();

            return entity.Entity;
        }
    }
}
