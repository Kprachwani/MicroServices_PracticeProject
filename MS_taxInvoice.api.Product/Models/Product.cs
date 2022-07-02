using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MS_taxInvoice.api.Product.Models
{
    public class Product
    {
        public int QRCodeNum { get; set; }
        public string Description { get; set; }
        public string CategoryNum { get; set; }
        public int ProductValue { get; set; }
    
    }
}
