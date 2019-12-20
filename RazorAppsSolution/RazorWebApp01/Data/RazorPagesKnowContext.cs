using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Knowledge;

namespace RazorWebApp01.Data
{
    public class RazorPagesKnowContext : DbContext
    {
        public RazorPagesKnowContext (DbContextOptions<RazorPagesKnowContext> options)
            : base(options)
        {
        }

        public DbSet<Knowledge.Nt> Nts { get; set; }
    }
}
