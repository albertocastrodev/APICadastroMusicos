using ApiCadastroMusicos.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ApiCadastroMusicos.Infra.Database.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _dbContext;

        public GenericRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ValueTask<TEntity> GetById(int id)
        {
            return _dbContext.Set<TEntity>().FindAsync(id);
        }
    }
}
