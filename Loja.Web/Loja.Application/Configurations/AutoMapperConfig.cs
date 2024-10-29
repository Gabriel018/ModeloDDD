using AutoMapper;
using Loja.Application.ViewModels;
using Loja.Domain.Entities;
namespace Loja.Application.Configurations
{
    public class AutoMapperConfig: Profile
    {
        public AutoMapperConfig() {

            CreateMap<ClienteViewModel, Cliente>().ReverseMap();
        }   
    }
}
