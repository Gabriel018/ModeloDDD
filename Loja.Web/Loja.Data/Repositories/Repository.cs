using Loja.Data.Repositories.IRepository;
using Loja.Domain.Entities;
using Loja.Web.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace Loja.Data.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly ApplicationDbContext Db ;
        protected readonly DbSet<TEntity> DbSet;
        protected Repository(ApplicationDbContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }
        public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }
        public virtual async Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }
        public virtual async Task<TEntity> ObterPorId(Guid id)
        {
            return await DbSet.FindAsync(id);
        }


        public virtual async Task<List<TEntity>> ObterTodos()
        {
            return await DbSet.ToListAsync();
        }
        public virtual async Task Adicionar(TEntity entity)
        {
            try
            {
                DbSet.Add(entity);
                await SaveChanges();
            }

            catch (Exception ex)
            {
                throw new ValidationException("Erro ao obter entidade no banco de dados.", ex);
            }
        }
        public async Task AdicionarLista(IEnumerable<TEntity> entities)
        {
            try
            {
                DbSet.AddRange(entities);
                await SaveChanges();
            }

            catch (Exception ex)
            {
                throw new ValidationException("Erro ao adicionar lista no banco de dados", ex);
            }
        }
        public virtual async Task Atualizar(TEntity entity)
        {
            try
            {
                DbSet.Update(entity);
                await SaveChanges();
            }
            catch (Exception ex)
            {
                throw new ValidationException("Erro ao alterar a entidade ao banco de dados.", ex);
            }
        }

        public virtual async Task AtualizarLista(IEnumerable<TEntity> entities)
        {
            try
            {
                DbSet.UpdateRange(entities);
                await SaveChanges();
            }

            catch (Exception ex)
            {
                throw new ValidationException("Erro ao alterar lista a entidade no banco de dados.", ex);
            }
        }
        public virtual async Task Remover(Guid id)
        {
            try
            {
                DbSet.Remove(new TEntity { Id = id });
                await SaveChanges();
            }

            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }

        public async Task<int> CountByBusiness(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.CountAsync(predicate);
        }

        public async Task<int> Count()
        {
            return await DbSet.CountAsync();
        }
        public void Dispose()
        {
            Db?.DisposeAsync();
        }
    }
}
