using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Knowledge;
using RazorWebApp01.Data;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace RazorWebApp01.Pages.Knowledge
{
    public class CreateModel : PageModel
    {
        public readonly RazorWebApp01.Data.RazorPagesKnowContext _context;
        private readonly IWebHostEnvironment hostingEnvironment;

        public CreateModel(RazorWebApp01.Data.RazorPagesKnowContext context, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            this.hostingEnvironment = hostingEnvironment;
        }

        public IActionResult OnAddBlkGet()
        {
            return Page();
        }
        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Nt Nt { get; set; }

        public IFormFile Photo { get; set; }

        public IActionResult UploadOneFile(IFormFile f)
        {
            using (var filestream = new FileStream(Path.Combine(hostingEnvironment.WebRootPath, "imagesUploaded"), FileMode.Create))
            {
                f.CopyTo(filestream);
            }
            return Page();
        }

        public IActionResult UploadManyFile( IEnumerable<IFormFile> fs)
        {
            int i = 0;
                foreach (var file in fs)
            { using (var filestream = new FileStream(Path.Combine(hostingEnvironment.WebRootPath, "imagesUploaded"), FileMode.Create))
                {
                    file.CopyTo(filestream);
                }
            
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

            _context.Nts.Add(Nt);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
