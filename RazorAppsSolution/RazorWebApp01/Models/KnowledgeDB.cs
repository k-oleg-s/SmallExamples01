using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Knowledge
{
   
    public class Nt
    {
        public int Id { get; set; }

        [Required, StringLength(10)]
        public string text { get; set; }
        public string tags { get; set; }
        public string pics { get; set; }
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
