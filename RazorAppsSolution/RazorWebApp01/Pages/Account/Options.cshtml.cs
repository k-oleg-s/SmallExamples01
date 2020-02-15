using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Knowledge;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorWebApp01.Data;

namespace RazorWebApp01
{
    public class OptionsModel : PageModel

    {
        public string  uName { get; set; }
        public string ExistingPhotoPath { get; set; }
     

        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public readonly RazorPagesKnowContext _context;
        // private readonly IdentityUser currentuser;
        [BindProperty]
        public Knowledge.UserOptions _uo { get; set; }
        public Lang ll { get; set; }
        public Lang nl { get; set; }
        //public 
        public OptionsModel(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager,
            Knowledge.UserOptions uo, RazorPagesKnowContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _uo = uo;                       
        }
        public void OnGet()
        {
                SelectList langs = new SelectList(Enum.GetNames(typeof(Lang)));           

            if (_signInManager.IsSignedIn(User))
            {
                uName = User.Identity.Name;

                Knowledge.UserOptions _uo2 = _context.Uoptions.FirstOrDefault(p => p.user.UserName == User.Identity.Name);
                ll = _uo2.toLang; nl = _uo2.fromLang; 
                if (_uo2 != null)  _uo = _uo2 ;
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            _context.Attach(_uo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OptionExists(_uo.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool OptionExists(int id)
        {
            return _context.Uoptions.Any(e => e.ID == id);
        }
    }
}