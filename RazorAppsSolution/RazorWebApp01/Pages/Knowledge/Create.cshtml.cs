using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesContacts.Models;
using System.Threading.Tasks;

namespace Knowledge
{
    public class CreateModel : PageModel
    {
        private readonly KnowledgeContext _context;

        public CreateModel(KnowledgeContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Page mPage { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Pages.Add(mPage);
            await _context.SaveChangesAsync();

            return RedirectToPage("./NameIndex");
        }
    }
}