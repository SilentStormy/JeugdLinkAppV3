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

            private readonly ILogger<CourseRepository> _logger;
            private readonly ApplicationContext _dbcontext;
        

        public CourseRepository(ApplicationContext applicationContext, ILogger<CourseRepository> logger) : base(applicationContext)
        {
            _dbcontext = applicationContext;
            _logger = logger;
        }
        
        public IEnumerable<Course> GetAllCourses()
        {
            return GetAll();
        }

       

        public IEnumerable<Course> GetCourseByCategory(Category category)
            {
                if(category == null||category.categoryId<=0)
                {
                    throw new ArgumentNullException("Invalid Course obj or categoryId");
                }
                return GetByCondition(c => c.CategoryId == category.categoryId);
            }

            public Course GetCourseById(int id)
            {
                return GetById(id);
            }

        public IEnumerable<Course> SearchCourse(Course searchedcourse)
        {
            if (searchedcourse == null || string.IsNullOrWhiteSpace(searchedcourse.title))
            {
                throw new ArgumentNullException(nameof(searchedcourse), "The course parameter cannot be null or empty.");
            }
            return GetByCondition(C => !string.IsNullOrWhiteSpace(C.title) &&
        C.title.ToLower().Contains(searchedcourse.title.ToLower()));
        }

        public void TryEnrollCourse(Student student, Course course)
        {
            if (course == null || student == null)
            {
                throw new ArgumentNullException("Student of Course mag niet null zijn");

            }

            if (course.Enrolledstudents.Count >= course.maxstudents)
            {
                throw new InvalidOperationException("Deze cursus is al vol!");
            }

            if (course.Enrolledstudents.Any(e => e.studentid == student.StudentId))
            {
                throw new InvalidOperationException("De ingelogde student is al ingeschreven in deze cursus!");
            }

            course.Enrolledstudents.Add(new Enrolledstudent { student = student, course = course });
        }
    }


    }

