using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MS_taxInvoice.api.Product.Interface
{
    public interface IProductsProvider
    {
        Task<(bool IsSuccess, IEnumerable<MS_taxInvoice.api.Product.Models.Product> Products, string ErrorMessage)> GetProductsAsync();
        Task<(bool IsSuccess, Models.Product Product, string ErrorMessage)> GetProductAsync(int QRCodeNum);
    }
}
