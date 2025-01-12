using Core.Entities;
using JeugdLinkBLL.Interfaces;
using JeugdLinkBLL.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using System.Security.Claims;

namespace JeugdLinkApp.Pages
{
    public class CursusModel : PageModel
    {
        private readonly ICourseservice _courseservice;
        private readonly ILogger<CursusModel> _logger;
        private readonly UserManager<IdentityUser> _userManager;

        public CursusModel(ICourseservice courseservice,ILogger<CursusModel> logger,UserManager<IdentityUser> userManager)
        {
            _courseservice = courseservice;
            _logger = logger;
            _userManager= userManager;
        }
        public Course course;
       

        [BindProperty] 
        public string CurrentRole { get; set; }
        public IActionResult OnGet(int id)
        {
            try
            {
                course = _courseservice.GetCourseById(id);
                if (course == null)
                {
                    return RedirectToPage("/Error");
                }
                var user = _userManager.GetUserAsync(User).Result;
                var roles = _userManager.GetRolesAsync(user).Result;
                CurrentRole = roles.FirstOrDefault();
                return Page();

            }
            catch(Exception ex)
            {
                _logger.LogError(string.Empty, ex.Message);
            }
            return Page();
        }

        public async Task<IActionResult> OnPostEnroll(int id)
        {
            try
            {
                course = _courseservice.GetCourseById(id);
                if (course == null)
                {
                    TempData["ErrorMessage"] = "Deze cursus is niet gevonden!";
                    return RedirectToPage("/Error");
                }


               var user=await _userManager.GetUserAsync(User) as Student;
              
                _courseservice.TryEnrollCourse(user, course);

                TempData["SuccessMessage"] = "Je bent succesvol ingeschreven!";
                return RedirectToPage("/Cursus", new { id });
                


            }
            catch (InvalidOperationException ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToPage("/Cursus", new { id });
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred: {ex.Message}");
                return RedirectToPage("/Error");
            }

        }

        
    }
}

