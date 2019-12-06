using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesContacts.Models;
using System;
using System.Threading.Tasks;

namespace Knowledge
{
    public class EditModel : PageModel
    {
        private readonly KnowledgeContext _context;

        public EditModel(KnowledgeContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Page epage { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            epage = await _context.Pages.FindAsync(id);

            if (epage == null)
            {
                return RedirectToPage("./Index");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(epage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new Exception($"Customer {epage.Id} not found!");
            }

            return RedirectToPage("./Index");
        }

    }
}