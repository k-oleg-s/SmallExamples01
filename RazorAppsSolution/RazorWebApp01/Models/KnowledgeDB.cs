using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Knowledge
{
   public enum Lang {[Display(Name = "English")] ENG, [Display(Name = "Russian")] RUS, [Display(Name = "German")] GER }
    public class Nt
    {
        public int Id { get; set; }
       
        [Required]
        public string word { get; set; }
        public string translation { get; set; }

        public Lang wordLng { get; set; }
        public Lang transLng { get; set; }

        public ICollection<Tag> stags { get; set; }
        public ICollection<Example> examples { get; set; }
        public string pics { get; set; }
        public byte? mark { get; set; }


        public IdentityUser Owner { get; set; }
        public Boolean shared { get; set; }
        public string text { get; set; }
    }

    public class Example
    {
        public int ID { get; set; }
        public ICollection<Tag> tags { get; set; }
        [Required]
        public string exampletext{ get; set; }
    }

    public class Tag
    {
        public int ID { get; set; }
        [Required]
        public  string txt { get; set; }
    }

    public class UserOptions
    {
        public int ID { get; set; }
        public IdentityUser user { get; set; }
        public Lang toLang { get; set; }
        public Lang fromLang { get; set; }
        public Boolean share { get; set; }
    }



    //public class SliteRepo:IKnowrepo 
    //{
    //    private readonly KnowledgeContext context;
    //    public SliteRepo(KnowledgeContext cntxt)
    //    {
    //        context = cntxt;
    //    }

    //    public Nt AddPage(Nt pg)
    //    {
    //        if (pg != null)
    //        {
    //            context.Add(pg);
    //            context.SaveChangesAsync();
    //        }
    //        return pg;
    //    }

    //    public Nt DelPage(int id)
    //    {
    //        Nt pg = context.Pages.Find(id);
    //        if (pg != null)
    //        {
    //            context.Pages.Remove(pg);
    //        }
    //        return pg;
    //    }

    //    public Nt UpdatePage(Nt pgtoupd)
    //    {
    //        var pg = context.Pages.Attach(pgtoupd);
    //        pg.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
    //        context.SaveChanges();
    //        return pgtoupd;
    //    }

    //    public Nt GetPage(int id)
    //    {
    //        return  context.Pages.Find(id);
    //    }

    //    public IEnumerable<Nt> GetPages()
    //    {
    //        return context.Pages;
    //    }
    //}
    //interface IKnowrepo
    //{ Nt GetPage(int id);
    //    Nt AddPage(Nt pg);
    //    Nt DelPage(int id);
    //    Nt UpdatePage(Nt pg);
    //    IEnumerable<Nt> GetPages();
    //}


    //public class KnowledgeContext : DbContext
    //{
    //    public KnowledgeContext(DbContextOptions<KnowledgeContext> options) : base(options)
    //    {

    //    }
    //    public DbSet<Nt> Pages { get; set; }

    //    //protected override void OnConfiguring(DbContextOptionsBuilder options)
    //    //    => options.UseSqlite("Data Source=knowledge.db");
    //}

}
