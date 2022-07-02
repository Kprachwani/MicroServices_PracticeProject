using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MS_taxInvoice.api.Product.db
{
    public class Product
    {
        [Key]
        public int QRCodeNum { get; set; }
        public string Description { get; set; }
        public string CategoryNum { get; set; }
        public int ProductValue { get; set; }
    }
}
