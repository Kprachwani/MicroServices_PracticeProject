using Microsoft.AspNetCore.Mvc;
using MS_taxInvoice.api.taxInvoice.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MS_taxInvoice.api.taxInvoice.Controllers
{
    [ApiController]
    [Route("api/taxInvoices")]
    public class taxInvoiceController : ControllerBase
    {
        private readonly ItaxInvoiceProvider taxInvoiceProvider;

        public taxInvoiceController(ItaxInvoiceProvider taxInvoiceProvider)
        {
            this.taxInvoiceProvider = taxInvoiceProvider;
        }

        [HttpGet]
        public async Task<IActionResult> GettaxInvoicesAsync()
        {
            var result = await taxInvoiceProvider.GettaxInvoicesAsync();
            if (result.IsSuccess)
            {
                return Ok(result.taxInvoices);
            }
            return NotFound();
        }

        [HttpGet("{invoiceNo}")]
        public async Task<IActionResult> GettaxInvoiceAsync(int invoiceNo)
        {
            var result = await taxInvoiceProvider.GettaxInvoiceAsync(invoiceNo);
            if (result.IsSuccess)
            {
                return Ok(result.taxInvoice);
            }
            return NotFound();
        }
    }
}
