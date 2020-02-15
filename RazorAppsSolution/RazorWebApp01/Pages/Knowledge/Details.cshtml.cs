using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Knowledge;
using RazorWebApp01.Data;

namespace RazorWebApp01.Pages.Knowledge
{
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesKnowContext _context;
        private readonly UserOptions _uo;
        public DetailsModel(RazorPagesKnowContext context, UserOptions uo)
        {
            _context = context;
            _uo = uo;
            msg = "...";
            got_mark = 0;
        }

        public int dId { get; set; }
        public int? nId { get; set; }
        public string dExistingPhotoPath { get; set; }
        //[BindProperty]
        public Nt pNt { get; set; }
        public byte got_mark { get; set; }
        public string msg { get; set; }


        public void OnPostWay(byte mark)
        {
            //Nt =  _context.Nts.FirstOrDefault(k => k.Id == id);
            got_mark = mark;
            pNt.mark = 11;
            //msg += "m=" + m + " did=" + dId;
            //return Page();
        } 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //nId = " nId" +id;
            msg += " nId=" + nId;
            pNt = await _context.Nts.FirstOrDefaultAsync(k => k.Id == id);

            if (pNt == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
