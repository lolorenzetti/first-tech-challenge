using AutoMapper;
using TechChallenge.Application.DTO;
using TechChallenge.Domain.Entities;

namespace TechChallenge.Application.Mappers
{
    public sealed class ClienteMapper : Profile
    {
        public ClienteMapper()
        {
            CreateMap<Cliente, VisualizarClienteDTO>();
        }
    }
}
