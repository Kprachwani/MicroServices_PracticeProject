using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MS_taxInvoice.api.Details.db
{
    public class DetailItem
    {
        [Key]
        public int ID { get; set; }
        public int srNo { get; set; }
        public int QRCodeNum { get; set; }
        public int qty { get; set; }
        public int Value { get; set; }
    }
}
