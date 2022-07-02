using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MS_taxInvoice.api.Search.Models
{
    public class Detail
    {
        public int srNo { get; set; }
        public string manufacturingCountry { get; set; }
        public DateTime invoiceDate { get; set; }
        public List<DetailItem> Items { get; set; }
    }
}
