using Core.Repositories.Base;
using JeugdLinkDAL.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JeugdLinkDAL.Repositories.Base
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationContext _dbcontext;

        public Repository(ApplicationContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<T> AddAsync(T entity)
        {
            _dbcontext.Set<T>().Add(entity);
            await _dbcontext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _dbcontext.Set<T>().Remove(entity);
            await _dbcontext.SaveChangesAsync();

        }

        public async Task UpdateAsync(T entity)
        {
            _dbcontext.Entry(entity).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
        }
     
        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _dbcontext.Set<T>().ToListAsync();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>>? filter = null)
        {
            IQueryable<T> query = _dbcontext.Set<T>();
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return query.FirstOrDefault();
        }


    }
}
