using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Knowledge;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorWebApp01.Data;

namespace RazorWebApp01
{
    public class LoginModel : PageModel
    {

        [BindProperty]
        public string username { get; set; }
        [BindProperty]
        public string pass { get; set; }

        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private Knowledge.UserOptions _uo;
        public readonly RazorPagesKnowContext _context;
        public LoginModel(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, 
            RazorPagesKnowContext context, Knowledge.UserOptions uo)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _uo = uo;
            _context = context;
        }

        public async Task<IActionResult> OnPost()
        {
            //login functionality
            var userx =await   _userManager.FindByNameAsync(username);
            
            if (userx != null)
            {
                //sign in
                var signInResult =  _signInManager.PasswordSignInAsync(userx, pass, false, false);

                if (signInResult.Result.Succeeded)
                {
                    Knowledge.UserOptions _uo2 = _context.Uoptions.FirstOrDefault(p => p.user == userx);
                    if (_uo2!=null) { _uo.ID = _uo2.ID; _uo.toLang = _uo2.toLang; _uo.fromLang = _uo2.fromLang; }
                    else {
                        int maxid = _context.Uoptions.Max(s => (int?)s.ID) ?? 1;
                        _uo = new Knowledge.UserOptions { user = userx, toLang = Lang.ENG, fromLang = Lang.RUS};
                        _context.Uoptions.Add(_uo);
                        _context.SaveChanges();
                    }
                     return RedirectToPage("/Account/Options");
                }
            }
            return RedirectToPage("/Account/Options");
        }
        public void OnGet()
        {

        }
    }
}