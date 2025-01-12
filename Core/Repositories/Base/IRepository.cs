using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories.Base
{
    public interface IRepository<T> where T : class
    {

        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

        void RemoveRange(IEnumerable<T> entity);  
        IEnumerable<T> GetAll();
        T GetFirstOrDefault(Expression<Func<T, bool>>? filter=null);
        T GetById(int id);
        IEnumerable<T> GetByCondition(Expression<Func<T, bool>>? filter = null);  

        

    }
}
