using AutoMapper;
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
    public class DetailsService : IDetailsSecrvice
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly ILogger<DetailsService> logger;

        public DetailsService(IHttpClientFactory httpClientFactory, ILogger<DetailsService> logger)
        {
            this.httpClientFactory = httpClientFactory;
            this.logger = logger;
        }

        public async Task<(bool IsSuccess, IEnumerable<Detail> details, string ErrorMessage)> GetDetailsAsync(int invoiceNo)
        {
            try
            {
                var client = httpClientFactory.CreateClient("DetailsService");
                var response = await client.GetAsync($"api/details/{invoiceNo}");
                if(response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsByteArrayAsync();
                    var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive=true};
                    var result = JsonSerializer.Deserialize<IEnumerable<Detail>>(content, options);
                    return (true, result, null);
                }
                return (false, null, response.ReasonPhrase);
            }
            catch(Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }
    }
}
