using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MS_taxInvoice.api.Details.db
{
    public class DetailsDbContext : DbContext
    {
        public DbSet<Detail> Detail { get; set; }
        public DetailsDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
