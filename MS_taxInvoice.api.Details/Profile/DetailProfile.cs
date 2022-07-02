using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MS_taxInvoice.api.Details.Profile
{
    public class DetailProfile : AutoMapper.Profile
    {
        public DetailProfile()
        {
            CreateMap<db.Detail, Models.Detail>();
            CreateMap<db.DetailItem, Models.DetailItem>();
        }
    }
}
