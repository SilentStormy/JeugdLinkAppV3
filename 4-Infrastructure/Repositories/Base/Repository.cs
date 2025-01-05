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
        internal DbSet<T> dbSet;

        public Repository(ApplicationContext dbcontext)
        {
            _dbcontext = dbcontext;
            this.dbSet=dbcontext.Set<T>(); 
        }

       
        public T GetFirstOrDefault(Expression<Func<T, bool>>? filter = null)
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                query=query.Where(filter);
            }


            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = dbSet;
            return query.ToList();
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);  
        }

        public void Update(T entity)
        {
            dbSet.Update(entity);
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);
        }
        public void RemoveRange(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);
        }

        public IEnumerable<T> GetByCondition(Expression<Func<T, bool>>? filter = null)
        {
            return dbSet.Where(filter).ToList();
        }
    }
}
