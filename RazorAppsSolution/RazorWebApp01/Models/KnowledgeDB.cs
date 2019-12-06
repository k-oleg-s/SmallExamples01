using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Knowledge
{
   
    public class Page
    {
        public int Id { get; set; }

        [Required, StringLength(10)]
        public string text { get; set; }
        public string tags { get; set; }
        public string pics { get; set; }
    }

    public class SliteRepo:IKnowrepo 
    {
        private readonly KnowledgeContext context;
        public SliteRepo(KnowledgeContext cntxt)
        {
            context = cntxt;
        }

        public Page AddPage(Page pg)
        {
            if (pg != null)
            {
                context.Add(pg);
                context.SaveChangesAsync();
            }
            return pg;
        }

        public Page DelPage(int id)
        {
            Page pg = context.Pages.Find(id);
            if (pg != null)
            {
                context.Pages.Remove(pg);
            }
            return pg;
        }

        public Page UpdatePage(Page pgtoupd)
        {
            var pg = context.Pages.Attach(pgtoupd);
            pg.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return pgtoupd;
        }

        public Page GetPage(int id)
        {
            return  context.Pages.Find(id);
        }

        public IEnumerable<Page> GetPages()
        {
            return context.Pages;
        }
    }
    interface IKnowrepo
    { Page GetPage(int id);
        Page AddPage(Page pg);
        Page DelPage(int id);
        Page UpdatePage(Page pg);
        IEnumerable<Page> GetPages();
    }


    public class KnowledgeContext : DbContext
    {
        public DbSet<Page> Pages { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //    => options.UseSqlite("Data Source=knowledge.db");
    }

}
