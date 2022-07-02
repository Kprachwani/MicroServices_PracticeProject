using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MS_taxInvoice.api.Details.db;
using MS_taxInvoice.api.Details.Interface;
using MS_taxInvoice.api.Details.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MS_taxInvoice.api.Details.Provider
{
    public class DetailsProvider : IDetailsProvider
    {
        private readonly DetailsDbContext dbContext;
        private readonly ILogger<DetailsProvider> logger;
        private readonly IMapper mapper;

        public DetailsProvider(DetailsDbContext dbContext, ILogger<DetailsProvider> logger, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.logger = logger;
            this.mapper = mapper;

            SeedData();
        }

        private void SeedData()
        {
            if (!dbContext.Detail.Any())
            {
                dbContext.Detail.Add(new db.Detail() { srNo =1, invoiceNo=1, manufacturingCountry="USD", invoiceDate=DateTime.Now,
                    Items = new List<db.DetailItem>()
                    {
                        new db.DetailItem() { ID=1, srNo=1,QRCodeNum=1,qty=10, Value=5 },
                        new db.DetailItem() { ID=2, srNo=1,QRCodeNum=2,qty=3, Value=5 },
                        new db.DetailItem() { ID=3, srNo=2,QRCodeNum=2,qty=8, Value=50 }
                    }
                });
                dbContext.Detail.Add(new db.Detail() { srNo = 2, invoiceNo = 2, manufacturingCountry = "INR", invoiceDate = DateTime.Now,
                    Items = new List<db.DetailItem>()
                    {
                        new db.DetailItem() { ID=4, srNo=2,QRCodeNum=1,qty=10, Value=5 },
                        new db.DetailItem() { ID=5, srNo=2,QRCodeNum=2,qty=4, Value=5 },
                        new db.DetailItem() { ID=6, srNo=2,QRCodeNum=2,qty=9, Value=50 }
                    }
                });
                dbContext.Detail.Add(new db.Detail() { srNo = 3, invoiceNo = 3, manufacturingCountry = "EUR", invoiceDate = DateTime.Now,
                    Items = new List<db.DetailItem>()
                    {
                        new db.DetailItem() { ID=7, QRCodeNum=1,qty=10, Value=5 },
                        new db.DetailItem() { ID=8, QRCodeNum=3,qty=5, Value=5 },
                        new db.DetailItem() { ID=9, QRCodeNum=2,qty=8, Value=50 }
                    }
                });
                dbContext.Detail.Add(new db.Detail() { srNo = 4, invoiceNo = 4, manufacturingCountry = "AUD", invoiceDate = DateTime.Now,
                    Items = new List<db.DetailItem>()
                    {
                        new db.DetailItem() { ID=10, QRCodeNum=1,qty=10, Value=5 },
                        new db.DetailItem() { ID=11, QRCodeNum=2,qty=3, Value=5 },
                        new db.DetailItem() { ID=12, QRCodeNum=2,qty=8, Value=50 }
                    }
                });
                dbContext.SaveChanges();
            }


        }

        public async Task<(bool IsSuccess, IEnumerable<Models.Detail> details, string ErrorMessage)> GetDetailsAsync(int invoiceNo)
        {
            try
            {
                var Details = await dbContext.Detail.Where(d => d.invoiceNo == invoiceNo).Include(d=>d.Items).ToListAsync();
                if (Details != null && Details.Any())
                {
                    var result = mapper.Map<IEnumerable<db.Detail>, IEnumerable<Models.Detail>>(Details);
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
