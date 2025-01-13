using Core.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeugdLinkBLL.Interfaces
{
    public interface ICourseservice
    {
        IEnumerable<Course> GetAllCourses();
        IEnumerable<Course> GetCourseByCategory(Category category);
        Course GetCourseById(int id);
        void TryEnrollCourse(IdentityUser student, Course course);
        IEnumerable<Course> SearchCourse(Course course);
    }
}
