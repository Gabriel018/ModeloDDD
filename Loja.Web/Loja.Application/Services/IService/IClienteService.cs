namespace Loja.Application.Services.IService
{
    public interface IClienteService
    {
        Task<IList<ClienteService>> GetAll();
    }
}
