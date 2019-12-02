using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.FileProviders;
using System.Net.Mime;
using System.Threading.Tasks;

namespace SampleApp.Pages
{
    public class StreamedSingleFileUploadPhysicalModel : PageModel
    {
        private readonly IFileProvider _fileProvider;
        public IDirectoryContents PhysicalFiles { get; private set; }

        public StreamedSingleFileUploadPhysicalModel(IFileProvider fileProvider)
        {
            _fileProvider = fileProvider;
        }
        public void OnGet()
        {          PhysicalFiles =  _fileProvider.GetDirectoryContents(string.Empty);
        }
        //public async Task OnGetAsync()
        //{
  
        //}
        public IActionResult OnGetDownloadPhysical(string fileName)
        {
            var downloadFile = _fileProvider.GetFileInfo(fileName);

            return PhysicalFile(downloadFile.PhysicalPath, MediaTypeNames.Application.Octet, fileName);
        }

    }

}