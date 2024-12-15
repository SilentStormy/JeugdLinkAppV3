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

        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);


        Task<IReadOnlyList<T>> GetAllAsync();
        T GetFirstOrDefault(Expression<Func<T, bool>>? filter = null);

    }
}
