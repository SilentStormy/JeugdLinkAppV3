using Core.Entities;
using JeugdLinkBLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JeugdLinkApp.Pages
{
    public class CategoryDetailsModel : PageModel
    {
        private readonly ICourseservice _courseservice;

        public CategoryDetailsModel(ICourseservice courseservice)
        {
            _courseservice = courseservice;
           
        }
        public IEnumerable<Course> CourseByCategory { get; set; }
        public Category selectedCategory { get; set; }
        public int CategoryId { get; set; }
        public void OnGet(int id)
        {
            CategoryId = id;
            selectedCategory=new Category { categoryId=id};
            CourseByCategory=_courseservice.GetCourseByCategory(selectedCategory);
        }
    }
}
