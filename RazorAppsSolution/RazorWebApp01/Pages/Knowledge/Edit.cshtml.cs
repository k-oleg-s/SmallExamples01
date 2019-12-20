using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Knowledge;
using RazorWebApp01.Data;

namespace RazorWebApp01.Pages.Knowledge
{
    public class EditModel : PageModel
    {
        private readonly RazorWebApp01.Data.RazorPagesKnowContext _context;

        public EditModel(RazorWebApp01.Data.RazorPagesKnowContext context)
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

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Nt).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NtExists(Nt.Id))
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

        private bool NtExists(int id)
        {
            return _context.Nts.Any(e => e.Id == id);
        }
    }
}
