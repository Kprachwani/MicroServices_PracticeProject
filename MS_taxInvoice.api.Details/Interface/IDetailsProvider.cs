using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MS_taxInvoice.api.Details.Interface
{
    public interface IDetailsProvider
    {
        Task<(bool IsSuccess, IEnumerable<Models.Detail> details, string ErrorMessage)> GetDetailsAsync(int invoiceNo);
    }
}
