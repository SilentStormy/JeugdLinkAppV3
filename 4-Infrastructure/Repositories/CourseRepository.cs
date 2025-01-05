using Core.Entities;
using Core.Repositories;
using JeugdLinkDAL.Data;
using JeugdLinkDAL.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeugdLinkDAL.Repositories
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {

        private readonly ApplicationContext _dbcontext;
    private readonly ILogger<CourseRepository> _logger;

    public CourseRepository(ApplicationContext applicationContext, ILogger<CourseRepository> logger) : base(applicationContext)
    {
        _dbcontext = applicationContext;
        _logger = logger;
    }
        
    public IEnumerable<Course> GetAllCourses()
    {
        return _dbcontext.Course.ToList();
    }
    public IEnumerable<Course> GetCourseByCategory(Category category)
        {
            if(category == null||category.categoryId<=0)
            {
                throw new ArgumentNullException("Invalid Course obj or categoryId");
            }
            return GetByCondition(c => c.categoryid == category.categoryId);
        }
    }
}
