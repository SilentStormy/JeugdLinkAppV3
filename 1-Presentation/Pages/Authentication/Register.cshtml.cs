//using JeugdLinkBLL.Interfaces;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JeugLinkApp.Pages
{
    public class RegisterModel : PageModel
    {
        //private readonly IRegistration _registration;

        public RegisterModel(/*IRegistration registration*/)
        {
            //_registration = registration;
        }

        //[BindProperty]

        //public User newuser { get; set; }   
        public void OnGet()
        {
        }

        public async Task<ActionResult> OnPostAsync()
        {
            if (ModelState.IsValid) //validating the input of user
            {
                try
                {
                //    await _registration.Register(newuser);
                //    TempData["Registersuccess"] = "Registratie voltooid!";

                //    return RedirectToPage("/Index");

                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, $"An error occurred: {ex.Message}");
                    return Page();
                }
            }
            return Page();
        }
    }
}
