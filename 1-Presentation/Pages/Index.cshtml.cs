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
        private readonly ICourseManager _courseManager;

        public IndexModel(ILogger<IndexModel> logger, ICourseManager courseManager)
        {
            _logger = logger;
            _courseManager = courseManager;
        }

        [BindProperty]

        public List<Course> AllCourses { get; set; }=new List<Course>();
        public async Task<IActionResult> OnGet()
        {
            try
            {
                
                var courses=await _courseManager.GetAllCourses();
                AllCourses=new List<Course>(courses);

            }
            catch (Exception ex)
            {
                _logger.LogError(string.Empty, ex.Message);
            }

            return Page();
        }
    }
}