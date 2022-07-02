using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MS_taxInvoice.api.taxInvoice.db
{
    public class taxInvoiceDbContext : DbContext
    {

        public DbSet<taxInvoice> taxInvoice { get; set; }

        public taxInvoiceDbContext(DbContextOptions options) : base (options)
        {

        }
    }
}
