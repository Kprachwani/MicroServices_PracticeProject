using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MS_taxInvoice.api.Details.Models
{
    public class Detail
    {
        public int srNo { get; set; }
        public int invoiceNo { get; set; }
        public string manufacturingCountry { get; set; }
        public DateTime invoiceDate { get; set; }
        public List<DetailItem> Items { get; set; }

    }
}
