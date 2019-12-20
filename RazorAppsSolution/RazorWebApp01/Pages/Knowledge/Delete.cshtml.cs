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
    public class DeleteModel : PageModel
    {
        private readonly RazorWebApp01.Data.RazorPagesKnowContext _context;

        public DeleteModel(RazorWebApp01.Data.RazorPagesKnowContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Nt Nt { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Nt = await _context.Nts.FirstOrDefaultAsync(m => m.Id == id);

            if (Nt == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Nt = await _context.Nts.FindAsync(id);

            if (Nt != null)
            {
                _context.Nts.Remove(Nt);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
