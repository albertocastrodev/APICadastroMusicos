﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApiCadastroMusicos.Domain.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<List<TEntity>> GetAll();
        IQueryable<TEntity> GetAllAsQueryable();
        ValueTask<TEntity> GetById(Guid id);
    }
}
