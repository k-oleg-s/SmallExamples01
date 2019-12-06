using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Knowledge
{
    public class IndexModel : PageModel
    {
        private readonly KnowledgeContext _context;
        public IList<Page> Pages { get; set; }

        public IndexModel(KnowledgeContext context)
        {
            _context = context;
        }

       

        public async Task OnGetAsync()
        {
            Pages = await _context.Pages.ToListAsync();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var pg = await _context.Pages.FindAsync(id);

            if (pg != null)
            {
                _context.Pages.Remove(pg);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage();
        }
    }
}