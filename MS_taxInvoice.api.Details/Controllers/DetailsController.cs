using Microsoft.AspNetCore.Mvc;
using MS_taxInvoice.api.Details.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MS_taxInvoice.api.Details.Controllers
{
    [ApiController]
    [Route("api/details")]
    public class DetailsController : ControllerBase
    {
        private readonly IDetailsProvider detailsProvider;

        public DetailsController(IDetailsProvider detailsProvider)
        {
            this.detailsProvider = detailsProvider;
        }

        [HttpGet("{invoiceNo}")]
        public async Task<IActionResult> GetDetailsAsync(int invoiceNo)
        {
            var result = await detailsProvider.GetDetailsAsync(invoiceNo);
            if (result.IsSuccess)
            {
                return Ok(result.details);
            }
            return NotFound();
        }
    }
}
