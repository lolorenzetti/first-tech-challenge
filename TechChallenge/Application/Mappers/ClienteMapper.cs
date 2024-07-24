using Application.Models.ViewModel;
using AutoMapper;
using Domain.Entities;

namespace TechChallenge.Application.Mappings
{
    public sealed class ClienteMapper : Profile
    {
        public ClienteMapper()
        {
            CreateMap<Cliente, ClienteViewModel>();
        }
    }
}
