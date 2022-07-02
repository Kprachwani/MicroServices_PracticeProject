using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MS_taxInvoice.api.taxInvoice.Interface
{
    public interface ItaxInvoiceProvider
    {
        Task<(bool IsSuccess, IEnumerable<Models.taxInvoice> taxInvoices, string ErrorMessage)> GettaxInvoicesAsync();
        Task<(bool IsSuccess, Models.taxInvoice taxInvoice, string ErrorMessage)> GettaxInvoiceAsync(int invoiceNo);
    }
}
