using Core.Entities;
using JeugdLinkBLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JeugdLinkApp.Pages
{
    public class SearchResultModel : PageModel
    {
        private readonly ICourseservice _courseservice;
        private readonly ILogger<CursusModel> _logger;

        public SearchResultModel(ICourseservice courseservice, ILogger<CursusModel> logger)
        {
            _courseservice = courseservice;
            _logger = logger;
        }

        public IEnumerable<Course> SearchedCourses { get; set; }
        public Course SearchCourse { get; set; } = new Course();
    
       
        public void OnGet(string searchkeyword)
        {
            ViewData["searchkeyword"] = searchkeyword;
            if (!string.IsNullOrEmpty(searchkeyword))
            {
                SearchCourse = new Course { title = searchkeyword };
                SearchedCourses = _courseservice.SearchCourse(SearchCourse);
            }
            else
            {
                SearchedCourses = _courseservice.GetAllCourses();
            }
        }
    }
}
