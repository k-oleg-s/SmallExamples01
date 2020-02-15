using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using tstTagHelpers01.Model;

namespace tstTagHelpers01
{
    public class page01Model : PageModel
    {
        public string msg;
        public Data01 _d;
        public page01Model (Data01 d1)
        {
            msg = "..";
            _d = d1;
            //_d.txt = d1.txt;
            //_d.txt = "ctor";
        }

        public void  OnPostWay1(string data)
        {
            msg += " fromkey1=" + data;
            _d.txt = "pressed_k_1";
        }

        public     ActionResult     OnPostWay2(string data)
        {
            msg += " fromkey2=" + data;
            return Page();
        }

        public class Movie
        {
            public int ID { get; set; }
            public string Title { get; set; }
            public DateTime ReleaseDate { get; set; }
            public string Genre { get; set; }
            public decimal Price { get; set; }
        }
        public void OnGet()
        {
            _d.num = 10; _d.txt = "ten";
        }
    }
}