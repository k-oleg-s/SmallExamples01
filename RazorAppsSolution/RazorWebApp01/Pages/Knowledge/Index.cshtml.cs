using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Knowledge;
using RazorWebApp01.Data;

namespace RazorWebApp01.Pages.Knowledge
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesKnowContext _context;

        public IndexModel(RazorPagesKnowContext context, UserOptions uo)
        {
            _context = context;
        }

        public IList<Nt> Nts { get;set; }

        public async Task OnGetAsync()
        {
            Nts = await _context.Nts.ToListAsync();
        }
    }
}
