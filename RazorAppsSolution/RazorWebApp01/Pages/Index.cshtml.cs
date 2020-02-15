using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace RazorWebApp01.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }


        public int cnt = 0;
        public IActionResult IncrementCount()
        {
            cnt++;
            return Page();
        }
        public IActionResult OnGet()
        {
            return RedirectToPage("/Knowledge/Index");
        }
    }
}
