using Core.Entities;
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
    }
}
