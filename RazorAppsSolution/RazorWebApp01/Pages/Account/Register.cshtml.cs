using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Knowledge;
using RazorWebApp01.Data;

namespace RazorWebApp01
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public string username { get; set; }
        [BindProperty]
        public string pass { get; set; }

        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly Knowledge.UserOptions _uo;
        public readonly RazorPagesKnowContext _context;

        public RegisterModel(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager,
            Knowledge.UserOptions uo, RazorPagesKnowContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _uo = uo;
            _context = context;
        }

        public IActionResult OnPost()
        {

            //register functionality

            var user = new IdentityUser
            {
                UserName = username,
                Email = "",
            };

            var result =  _userManager.CreateAsync(user, pass);

            if (result.Result.Succeeded)
            {
                _uo.user = user;
                _uo.toLang = Lang.ENG; _uo.fromLang = Lang.RUS;
                _context.Uoptions.Add(_uo);
                _context.SaveChanges();
                //sign in
                var signInResult =  _signInManager.PasswordSignInAsync(user, pass, false, false);

                if (signInResult.Result.Succeeded)
                {
                    return RedirectToPage("/Account/Options");
                }
            }

            return RedirectToPage("/Account/Options");
        }

        public void OnGet()
        {
            //return Page();
        }
    }
}