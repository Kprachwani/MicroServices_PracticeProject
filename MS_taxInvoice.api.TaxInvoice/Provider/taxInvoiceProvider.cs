using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MS_taxInvoice.api.taxInvoice.db;
using MS_taxInvoice.api.taxInvoice.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MS_taxInvoice.api.taxInvoice.Provider
{
    public class taxInvoiceProvider : ItaxInvoiceProvider
    {
            private readonly taxInvoiceDbContext dbContext;
            private readonly ILogger<taxInvoiceProvider> logger;
            private readonly IMapper mapper;


            public taxInvoiceProvider(taxInvoiceDbContext dbContext, ILogger<taxInvoiceProvider> logger, IMapper mapper)
            {
                this.dbContext = dbContext;
                this.logger = logger;
                this.mapper = mapper;

                SeedData();

            }

            private void SeedData()
            {
                if (!dbContext.taxInvoice.Any())
                {
                    dbContext.taxInvoice.Add(new db.taxInvoice() { invoiceNo= 1, cityName="US", branchName="street1" });
                    dbContext.taxInvoice.Add(new db.taxInvoice() { invoiceNo = 2, cityName = "US", branchName = "street2" });
                    dbContext.taxInvoice.Add(new db.taxInvoice() { invoiceNo = 3, cityName = "DE", branchName = "street3" });
                    dbContext.taxInvoice.Add(new db.taxInvoice() { invoiceNo = 4, cityName = "AU", branchName = "street4" });
                    dbContext.SaveChanges();
                }
            }

            public async Task<(bool IsSuccess, IEnumerable<Models.taxInvoice> taxInvoices, string ErrorMessage)> GettaxInvoicesAsync()
            {
                try
                {
                    var taxInvoices = await dbContext.taxInvoice.ToListAsync();
                    if (taxInvoices != null && taxInvoices.Any())
                    {
                        var result = mapper.Map<IEnumerable<db.taxInvoice>, IEnumerable<Models.taxInvoice>>(taxInvoices);
                        return (true, result, null);
                    }
                    return (false, null, "Not Found");
                }
                catch (Exception ex)
                {
                    logger?.LogError(ex.ToString());
                    return (false, null, ex.Message);
                }
            }

            public async Task<(bool IsSuccess, Models.taxInvoice taxInvoice, string ErrorMessage)> GettaxInvoiceAsync(int invoiceNo)
            {
                try
                {
                    var taxInvoice = await dbContext.taxInvoice.FirstOrDefaultAsync(p => p.invoiceNo == invoiceNo);
                    if (taxInvoice != null)
                    {
                        var result = mapper.Map<db.taxInvoice, Models.taxInvoice>(taxInvoice);
                        return (true, result, null);
                    }
                    return (false, null, "Not Found");
                }
                catch (Exception ex)
                {
                    logger?.LogError(ex.ToString());
                    return (false, null, ex.Message);
                }
            }
        }
    }

