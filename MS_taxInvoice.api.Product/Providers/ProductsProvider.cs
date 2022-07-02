using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MS_taxInvoice.api.Product.db;
using MS_taxInvoice.api.Product.Interface;
using MS_taxInvoice.api.Product.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MS_taxInvoice.api.Product.Providers
{
    public class ProductsProvider : IProductsProvider
    {
        private readonly ProductsDbContext dbContext;
        private readonly ILogger<ProductsProvider> logger;
        private readonly IMapper mapper;
                

        public ProductsProvider(ProductsDbContext dbContext, ILogger<ProductsProvider> logger, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.logger = logger;
            this.mapper = mapper;

            SeedData();
        
        }

        private void SeedData()
        {
            if(!dbContext.Products.Any())
            {
                dbContext.Products.Add(new db.Product() { QRCodeNum = 1, Description = "MS PRoduct 1", CategoryNum = "11111111", ProductValue = 300 });
                dbContext.Products.Add(new db.Product() { QRCodeNum = 2, Description = "Car doors", CategoryNum = "22222222", ProductValue = 400 });
                dbContext.Products.Add(new db.Product() { QRCodeNum = 3, Description = "fruit", CategoryNum = "33333333", ProductValue = 500 });
                dbContext.Products.Add(new db.Product() { QRCodeNum = 4, Description = "animal", CategoryNum = "44444444", ProductValue = 600 });
                dbContext.SaveChanges();
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<Models.Product> Products, string ErrorMessage)> GetProductsAsync()
        {
            try
            {
                var products = await dbContext.Products.ToListAsync();
                if(products != null && products.Any())
                {
                   var result= mapper.Map<IEnumerable<db.Product>, IEnumerable<Models.Product>>(products);
                   return (true, result, null);
                }
                return (false, null, "Not Found");
            }
            catch(Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool IsSuccess, Models.Product Product, string ErrorMessage)> GetProductAsync(int QRCodeNum)
        {
            try
            {
                var product = await dbContext.Products.FirstOrDefaultAsync(p=> p.QRCodeNum== QRCodeNum);
                if (product != null)
                {
                    var result = mapper.Map<db.Product, Models.Product>(product);
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
