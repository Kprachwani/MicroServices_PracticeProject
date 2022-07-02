using Microsoft.AspNetCore.Mvc;
using MS_taxInvoice.api.Search.interfaces;
using MS_taxInvoice.api.Search.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MS_taxInvoice.api.Search.Controllers
{
    [ApiController]
    [Route("api/search")]
    public class SearchController: ControllerBase
    {
        private readonly ISearchService searchService;

        public SearchController(ISearchService searchService)
        {
            this.searchService = searchService;
        }

        [HttpPost]
        public async Task<IActionResult> SearchAsync(SearchTerm term)
        {
            var result = await searchService.SearchAsync(term.invoiceNo);
            if(result.IsSuccess)
            {
                return Ok(result.SearchResults);        
            }
            return NotFound();

        }
    }
}
