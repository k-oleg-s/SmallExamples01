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
        public readonly RazorPagesKnowContext _context;
        private readonly IWebHostEnvironment hostingEnvironment;
        private readonly UserOptions _uo;
        [BindProperty]
        public Nt bNt { get; set; }

        public CreateModel(RazorPagesKnowContext context, IWebHostEnvironment hostingEnvironment, UserOptions uo)
        {   
            this.hostingEnvironment = hostingEnvironment;
            _uo = uo;
            _context = context;
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
        public IFormFile Photo { get; set; }

        //public IActionResult UploadOneFile(IFormFile f)
        //{
        //    using (var filestream = new FileStream(Path.Combine(hostingEnvironment.WebRootPath, "imagesUploaded"), FileMode.Create))
        //    {
        //        f.CopyTo(filestream);
        //    }
        //    return Page();
        //}

        //public IActionResult UploadManyFile( IEnumerable<IFormFile> fs)
        //{
        //    //int i = 0;
        //        foreach (var file in fs)
        //    { using (var filestream = new FileStream(Path.Combine(hostingEnvironment.WebRootPath, "imagesUploaded"), FileMode.Create))
        //        {
        //            file.CopyTo(filestream);
        //        }            
        //    }
        //    return Page();
        //}

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost(IFormFile Photo2)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if (Photo != null)
                {                    
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(Photo.FileName);
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "imagesUploaded");
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    var filestream = new FileStream(filePath, FileMode.Create);
                    Photo.CopyTo(filestream);
                }

                Nt newNt = new Nt
                {
                    word  = bNt.word,
                    translation = bNt.translation,

                    wordLng=_uo.fromLang,
                    transLng=_uo.toLang,
   
                    mark=0,
                    pics = uniqueFileName
                };
                 _context.Nts.Add(newNt);
                 _context.SaveChanges();

                    return Page();
            }



            return RedirectToPage("./Index");
        }
    }
}
