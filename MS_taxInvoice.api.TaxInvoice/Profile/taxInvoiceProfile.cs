using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MS_taxInvoice.api.taxInvoice.Profile
{
    public class taxInvoiceProfile : AutoMapper.Profile
    {
        public taxInvoiceProfile()
        {
            CreateMap<db.taxInvoice, Models.taxInvoice>();
        }
    }
}
