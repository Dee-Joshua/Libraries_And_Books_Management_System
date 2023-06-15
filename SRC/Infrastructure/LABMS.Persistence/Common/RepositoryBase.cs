﻿using LABMS.Application.common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LABMS.Persistence.Common
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected RepositoryContext RepositoryContext;
        public RepositoryBase(RepositoryContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }
        public void Create(T entity) => RepositoryContext.Set<T>().Add(entity);

        public void Delete(T entity) => RepositoryContext.Set<T>().Remove(entity);

        public IQueryable<T> FindAll(bool trackChanges)
        {
            return !trackChanges ?
                RepositoryContext.Set<T>()
                .AsNoTracking() :
                RepositoryContext.Set<T>();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackchanges)
        {
            return !trackchanges ?
                RepositoryContext.Set<T>()
                .Where(expression)
                .AsNoTracking() :
                RepositoryContext.Set<T>()
                .Where(expression);

        }

        public void Update(T entity) => RepositoryContext.Set<T>().Update(entity);
    }
}
