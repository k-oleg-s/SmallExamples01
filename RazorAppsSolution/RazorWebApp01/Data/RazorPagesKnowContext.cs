using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Knowledge;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace RazorWebApp01.Data
{
    public class RazorPagesKnowContext : IdentityDbContext
    {
        public RazorPagesKnowContext (DbContextOptions<RazorPagesKnowContext> options)
            : base(options)
        {
        }

        public DbSet<Knowledge.Nt> Nts { get; set; }
        public DbSet<Knowledge.UserOptions> Uoptions { get; set; }

        public DbSet<Knowledge.Example> Examples { get; set; }
        public DbSet<Knowledge.Tag> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Seed();
        }
    }
}
