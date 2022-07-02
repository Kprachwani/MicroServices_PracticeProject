using MS_taxInvoice.api.Search.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MS_taxInvoice.api.Search.interfaces
{
    public interface IDetailsSecrvice
    {
        Task<(bool IsSuccess, IEnumerable<Detail> details, string ErrorMessage)> GetDetailsAsync(int invoiceNo);
    }
}
