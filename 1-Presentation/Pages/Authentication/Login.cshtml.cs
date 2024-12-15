
using JeugdLinkBLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Runtime.CompilerServices;

namespace JeugLinkApp.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IAuthenticator authenticator;

        public LoginModel(IAuthenticator authenticator)
        {
            this.authenticator = authenticator; 
        }
        [BindProperty]
        public string Email{ get; set; }

        [BindProperty]
        public string Password { get; set; }
        public void OnGet()
        {


        }

        public async Task<IActionResult> OnPostAsync()
        {
            if(!ModelState.IsValid)
            {
                return Page();  
            }

            try
            {
                var user = await authenticator.Login(Email,Password);
                return RedirectToPage("/Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"An error occured: {ex.Message}");
                return Page();
            }

            return Page();
        }
    }
}
