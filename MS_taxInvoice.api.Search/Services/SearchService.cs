using MS_taxInvoice.api.Search.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MS_taxInvoice.api.Search.Services
{
    public class SearchService : ISearchService
    {
        private readonly IDetailsSecrvice detailsSecrvice;
        private readonly IProductService productService;
        private readonly ItaxInvoicesService taxInvoicesService;
        public SearchService(IDetailsSecrvice detailsSecrvice, IProductService productService, ItaxInvoicesService taxInvoicesService)
        {
            this.detailsSecrvice = detailsSecrvice;
            this.productService = productService;
            this.taxInvoicesService = taxInvoicesService;
        }
        public async Task<(bool IsSuccess, dynamic SearchResults)> SearchAsync(int invoiceNo)
        {
            //await Task.Delay(1);
            //return (true, new { Message = "Hello" });

            var detailsResult = await detailsSecrvice.GetDetailsAsync(invoiceNo);
            var invoiceResult = await taxInvoicesService.GettaxInvoiceAsync(invoiceNo);
            var productsResult = await productService.GetProductsAsync();

            if(detailsResult.IsSuccess)
            {
                foreach(var details in detailsResult.details)
                {
                    foreach(var item in details.Items)
                    {
                        item.Description = productsResult.products.FirstOrDefault(p => p.QRCodeNum == item.QRCodeNum)?.Description;
                    }
                }

                var result = new
                {
                    taxInvoice = invoiceResult.taxInvoice,
                    details = detailsResult.details
                };
                return (true, result);
            }
            return (false, null);
        }
    }
}
