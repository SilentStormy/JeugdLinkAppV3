
using Core.Entities;
using JeugdLinkDAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using AutoMapper.Internal.Mappers;
using JeugdLinkBLL.Interfaces;
using JeugdLinkDAL.Data;
using Microsoft.Extensions.Logging;

namespace JeugdLinkBLL.Services
{
    public class CourseService : ICourseservice
    {
        private readonly ICourseRepository _courserepository;
        private readonly ILogger<CourseService> _logger; 

        public CourseService(ICourseRepository courseRepository,ILogger<CourseService> logger)
        {
            _courserepository = courseRepository;
            _logger = logger;
        }

        public IEnumerable<Course> GetAllCourses()
        {
            try
            {
                _logger.LogInformation("Fetching all the courses");
                return _courserepository.GetAllCourses();
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occured while fetching courses: {ex.Message}");
                throw;
            }
        }

       

        public IEnumerable<Course> GetCourseByCategory(Category category)
        {
            try
            {
                _logger.LogInformation("Fetching all the courses");
                return _courserepository.GetCourseByCategory(category);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occured while fetching courses: {ex.Message}");
                throw;
            }
        }
    }
}
