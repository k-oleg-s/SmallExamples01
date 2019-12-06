using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesTutorial.Pages
{
    public class SuppliersModel : PageModel
    {
        public int x  { get; set; }
        public string  xstr { get; set; }

        //public async Task<IActionResult> OnPost()
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return Page();
        //    }
            
        //}
        public void OnGet()
        {

        }

    }
}