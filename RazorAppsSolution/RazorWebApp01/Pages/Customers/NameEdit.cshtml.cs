using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesContacts.Models;
using System;
using System.Threading.Tasks;

namespace RazorPagesContacts.Pages.Customers
{
    public class EditModel : PageModel
    {
        private readonly CustomerDbContext _context;

        public EditModel(CustomerDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Customer eCustomer { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            eCustomer = await _context.Customers.FindAsync(id);

            if (eCustomer == null)
            {
                return RedirectToPage("./NameIndex");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(eCustomer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new Exception($"Customer {eCustomer.Id} not found!");
            }

            return RedirectToPage("./NameIndex");
        }

    }
}