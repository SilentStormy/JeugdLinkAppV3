using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Repositories;
using Core.Entities;
using JeugdLinkDAL.Repositories.Base;
using JeugdLinkDAL.Data;
using Microsoft.EntityFrameworkCore;

namespace JeugdLinkDAL.Repositories
{
    public class CourseRepository:Repository<Course>, ICourseRepository
    {
       
        private readonly ApplicationContext _dbcontext;
        private readonly ILogger<CourseRepository> _logger;

        public CourseRepository(ApplicationContext applicationContext, ILogger<CourseRepository> logger):base(applicationContext)
        {
            _dbcontext = applicationContext;
            _logger = logger;
        }
       

      
        public async Task<IReadOnlyList<Course>> GetAllCoursesAsync()
        {
            try
            {
                return await GetAllAsync();
                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured while fetching courses!");
                throw;
            }
        }

        }
    }

    
