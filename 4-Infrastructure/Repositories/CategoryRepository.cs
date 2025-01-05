using Core.Entities;
using Core.Repositories;
using JeugdLinkDAL.Data;
using JeugdLinkDAL.Repositories.Base;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeugdLinkDAL.Repositories
{

    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationContext _dbcontext;
       

        public CategoryRepository(ApplicationContext applicationContext): base(applicationContext)
        {
            _dbcontext = applicationContext;
        }


       public IEnumerable<Category> GetAll()
        {
            return _dbcontext.Category.ToList();

        }
    }
        

}
