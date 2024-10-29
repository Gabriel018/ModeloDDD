using Loja.Data.Repositories.IRepository;
using Loja.Domain.Entities;
using Loja.Web.Data.Contexts;

namespace Loja.Data.Repositories
{
    public class ClienteRepository : Repository<Cliente>,IClienteRepository
    {
        public ClienteRepository(ApplicationDbContext context) : base(context) {
            
        }
    }
}
