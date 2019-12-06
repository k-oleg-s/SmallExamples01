using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorWebApp01.Pages
{
    public class CounterModel : PageModel
    {
        public int x_cs = 100;
        public void OnGet()
        {
            x_cs++;
        }
    }
}