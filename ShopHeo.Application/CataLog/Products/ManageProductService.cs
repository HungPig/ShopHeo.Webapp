using ShopHeo.Application.CataLog.Products.Dtos.Manage;
using ShopHeo.Application.Dtos;
using ShopHeo.Data.EF;
using ShopHeo.Data.Entities;
using ShopHeo.Unlitiles;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShopHeo.Application.CataLog.Products
{
    public class ManageProductService : IManageProductService
    {
        private readonly HShopDBContext context;
        public ManageProductService(HShopDBContext context)
        {
            this.context = context;
        }

        public async Task AddViewCount(int ProductID)
        {
            var product = await this.context.Products.FindAsync(ProductID);
            product.ViewCount++;
            await this.context.SaveChangesAsync();
        }

        public async Task<int> Create(ProductCreateRequest request)
        {
            var product = new Product()
            {
                Price = request.Price,
                OriginalPrice = request.OriginalPrice,
                Stock = request.Stock,
                ViewCount = 0,
                DateCreated = DateTime.Now,
                ProductTranslations = new List<ProductTranslation>()
                {
                    new ProductTranslation()
                    {
                      Name = request.Name,
                      Description = request.Description,
                      Details = request.Details,
                      SeoAlias = request.SeoAlias,
                      SeoDescription = request.SeoDescription,
                      SeoTitle = request.SeoTitle,
                      LanguageId = request.LanguageId
                    }
                }

            };
            this.context.Products.Add(product);
            return await this.context.SaveChangesAsync();
        }

        public async Task<int> Delete(int ProductID)
        {
            var product = await this.context.Products.FindAsync(ProductID);
            if(product == null)
            {
                throw new HshopException($"Can't find a product: {ProductID}");
            }
            this.context.Products.Remove(product);
            return await this.context.SaveChangesAsync();
        }

        public async Task<List<ProductViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<PagedResult<ProductViewModel>> GetALLPagings(GetProductPagingRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Update(ProductEditRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdatePrice(int ProductID, decimal newPrice)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateStock(int ProductID, int addedQuantaliy)
        {
            throw new NotImplementedException();
        }

        public Task UpdateViewCount(int ProductID)
        {
            throw new NotImplementedException();
        }
    }
}
