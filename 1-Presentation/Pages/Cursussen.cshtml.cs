using Core.Entities;
using JeugdLinkBLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Org.BouncyCastle.Asn1.Mozilla;

namespace JeugdLinkApp.Pages
{
    public class CursussenModel : PageModel
    {
        private readonly ICourseservice _courseservice;
        private readonly ILogger<CursussenModel> _logger;

        public CursussenModel(ICourseservice courseservice, ILogger<CursussenModel> logger)
        {
            _courseservice = courseservice;
            _logger = logger;
        }

        public IEnumerable<Course> Courses { get; set; }
        public void OnGet()
        {
            try
            {
                Courses = _courseservice.GetAllCourses();
            }
            catch(Exception ex)
            {
                _logger.LogError(string.Empty, ex.Message);
            }
        }
    }
}
