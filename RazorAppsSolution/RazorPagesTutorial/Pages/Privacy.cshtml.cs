using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace RazorPagesTutorial.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;
        private readonly IWebHostEnvironment hostingEnvironment;
        public string Message { get; private set; } = "PageModel in C#";
        public IFormFile Photo { get; set; }

        public PrivacyModel(ILogger<PrivacyModel> logger, IWebHostEnvironment hostingEnvironment)
        {
            _logger = logger;
            this.hostingEnvironment = hostingEnvironment;
        }

        public void OnGet()
        {
            Message += $" Server time is { DateTime.Now }";
        }

        public  IActionResult OnPostUpload(List<IFormFile> files)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if (Photo != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                    string untrustedFileName = Path.GetFileName(Photo.FileName);
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + untrustedFileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    Message = "uploaded file=" + filePath;
                    // Use CopyTo() method provided by IFormFile interface to
                    // copy the file to wwwroot/images folder
                    Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                }
            }

                    //long size = files.Sum(f => f.Length);
                    //var filePath = Path.GetTempFileName();

                    //foreach (var formFile in files)
                    //{
                    //    if (formFile.Length > 10)
                    //    {                 
                    //        using (var stream = System.IO.File.Create(filePath))
                    //        {
                    //            await formFile.CopyToAsync(stream);
                    //        }
                    //    }
                    //}
                    //Message="count="+files.Count  + filePath;
                    return Page(); //new { count = files.Count, size, filePath };
        }
    }
}
