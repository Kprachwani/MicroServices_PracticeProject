using MS_taxInvoice.api.Search.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MS_taxInvoice.api.Search.interfaces
{
    public interface ItaxInvoicesService
    {
        Task<(bool IsSuccess, taxInvoice taxInvoice, string ErrorMessage)> GettaxInvoiceAsync(int invoiceNo);
    }
}
