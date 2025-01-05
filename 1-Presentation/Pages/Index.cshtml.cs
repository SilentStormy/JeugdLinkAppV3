using Core.Entities;
using Core.Repositories;
using JeugdLinkBLL.Interfaces;
using JeugdLinkDAL.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JeugLinkApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ICategoryservice _categoryservice;
        private readonly ICourseservice _courseservice;

        public IndexModel(ILogger<IndexModel> logger, ICategoryservice categoryservice,ICourseservice courseservice)
        {
            _logger = logger;
            _categoryservice = categoryservice;
           _courseservice= courseservice;
          
        }


        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Course> Courses { get; set; } 
        public IEnumerable<Course> CourseByCategory { get; set; }
        public int? SelectedCategoryId { get; set; }
        public void OnGet(int? categoryId)
        {
            try
            {
                Categories = _categoryservice.GetAllCategories();
                SelectedCategoryId = categoryId;
                if(categoryId.HasValue)
                {
                    var SelectedCategory = Categories.FirstOrDefault(c => c.categoryId == categoryId);
                    if(SelectedCategory != null)
                    {
                        Courses=_courseservice.GetCourseByCategory(SelectedCategory);
                    }
                }
               
                Courses = _courseservice.GetAllCourses();
                ViewData["Category"]=Categories;
                ViewData["Course"] = Courses;

            }
            catch (Exception ex)
            {
                _logger.LogError(string.Empty, ex.Message);
            }

           
        }
    }
}