using Microsoft.Extensions.Logging;
using MS_taxInvoice.api.Search.interfaces;
using MS_taxInvoice.api.Search.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace MS_taxInvoice.api.Search.Services
{
    public class taxInvoicesService : ItaxInvoicesService
    {

        private readonly IHttpClientFactory httpClientFactory;
        private readonly ILogger<taxInvoicesService> logger;

        public taxInvoicesService(IHttpClientFactory httpClientFactory, ILogger<taxInvoicesService> logger)
        {
            this.httpClientFactory = httpClientFactory;
            this.logger = logger;
        }
                
        public async Task<(bool IsSuccess, taxInvoice taxInvoice, string ErrorMessage)> GettaxInvoiceAsync(int invoiceNo)
        {
            try
            {
                var client = httpClientFactory.CreateClient("taxInvoicesService");
                var response = await client.GetAsync($"api/taxInvoices/{invoiceNo}");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsByteArrayAsync();
                    var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                    var result = JsonSerializer.Deserialize<taxInvoice>(content, options);
                    return (true, result, null);
                }
                return (false, null, response.ReasonPhrase);
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }
    }
}
