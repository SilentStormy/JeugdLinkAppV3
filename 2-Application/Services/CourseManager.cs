using JeugdLinkBLL.Interfaces;
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

namespace JeugdLinkBLL.Services
{
    public class CourseManager : ICourseManager
    {
        private readonly ICourseRepository _courseRepository;

        public CourseManager(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;

        }

        public async Task<IEnumerable<Course>> GetAllCourses()
        {
           return await _courseRepository.GetAllCoursesAsync();
            
        }
    }
}
