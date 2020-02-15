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
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace RazorWebApp01.Pages.Knowledge
{
    public class EditModel : PageModel
    {
        private readonly RazorWebApp01.Data.RazorPagesKnowContext _context;
        private readonly IWebHostEnvironment hostingEnvironment;

        public EditModel(RazorPagesKnowContext context, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            this.hostingEnvironment = hostingEnvironment;

            //Id =Nt.Id; 
            //ExistingTxt = Nt.text; 
            //ExistingPhotoPath = Nt.pics;
        }

        [BindProperty]
        public Nt Nt { get; set; }
        public IFormFile Photo { get; set; }




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


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Photo != null)
            {
                // If a new photo is uploaded, the existing photo must be
                // deleted. So check if there is an existing photo and delete
                if (Nt.pics != null)
                {
                    string filePath = Path.Combine(hostingEnvironment.WebRootPath,
                        "imagesUploaded", Nt.pics);
                    System.IO.File.Delete(filePath);
                }
                // Save the new photo in wwwroot/images folder and update
                // PhotoPath property of the employee object which will be
                // eventually saved in the database
                Nt.pics = ProcessUploadedFile();
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

        private string ProcessUploadedFile( )
        {
            string uniqueFileName = null;
            if (Photo != null)
            {

                uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(Photo.FileName);
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "imagesUploaded");
                // + "_" + "f.jpg"; 
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                var filestream = new FileStream(filePath, FileMode.Create);
                Photo.CopyTo(filestream);
               
            }
        return uniqueFileName;
        }

            private bool NtExists(int id)
        {
            return _context.Nts.Any(e => e.Id == id);
        }
    }
}
