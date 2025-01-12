
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
    public class CourseManager : ICourseservice
    {
        private readonly ICourseRepository _courserepository;
        private readonly ILogger<CourseManager> _logger;

        public CourseManager(ICourseRepository courseRepository, ILogger<CourseManager> logger)
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

        public Course GetCourseById(int id)
        {
            try
            {
                _logger.LogInformation("Fetching all the courses");
                return _courserepository.GetCourseById(id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occured while fetching courses: {ex.Message}");
                throw;
            }

        }

        public IEnumerable<Course> SearchCourse(Course course)
        {
            try
            {
                return _courserepository.SearchCourse(course);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while searching for courses: {ex.Message}");
                throw;
            }
        }

        public void TryEnrollCourse(Student student, Course course)
        {
            try
            {
                _logger.LogInformation("Fetching all the courses");
                 _courserepository.TryEnrollCourse(student, course);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occured while fetching courses: {ex.Message}");
                throw;
            }
        }

        
    }
}
