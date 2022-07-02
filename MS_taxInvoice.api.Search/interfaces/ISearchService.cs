using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MS_taxInvoice.api.Search.interfaces
{
    public interface ISearchService
    {
        Task<(bool IsSuccess, dynamic SearchResults)> SearchAsync(int invoiceNo);
    }
}
