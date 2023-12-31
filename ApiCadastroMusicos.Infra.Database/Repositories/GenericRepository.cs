﻿using ApiCadastroMusicos.Domain.Repositories;
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

        public ValueTask<TEntity> GetById(Guid id)
        {
            return _dbContext.Set<TEntity>().FindAsync(id);
        }

        public Task<List<TEntity>> GetAll()
        {
            return _dbContext
                .Set<TEntity>()
                .ToListAsync();
        }
        public IQueryable<TEntity> GetAllAsQueryable()
        {
            return _dbContext
                .Set<TEntity>()
                .AsQueryable();
        }
    }
}
