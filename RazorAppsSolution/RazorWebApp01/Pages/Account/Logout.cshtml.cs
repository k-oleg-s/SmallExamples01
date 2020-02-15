using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorWebApp01
{
    public class LogoutModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public  string crntusr="some user";

        public LogoutModel(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;

        }

        public async Task<IActionResult> OnPost()
        {
            if (_signInManager.IsSignedIn(User))
            {
                crntusr = User.Identity.Name;
            }
            await _signInManager.SignOutAsync();
            return Page();
        }
        public void OnGet()
        {

        }
    }
}