using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MS_taxInvoice.api.taxInvoice.db
{
    public class taxInvoice
    {
        [Key]
        public int invoiceNo { get; set; }
        public string cityName { get; set; }
        public string branchName { get; set; }
    }
}
