using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MS_taxInvoice.api.Details.Models
{
    public class DetailItem
    {
        public int ID { get; set; }
        public int QRCodeNum { get; set; }
        public int qty { get; set; }
        public int Value { get; set; }
    }
}
