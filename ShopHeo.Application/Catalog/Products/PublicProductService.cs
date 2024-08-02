using ShopHeo.Application.Dtos;
using ShopHeo.Data.EF;
using ShopHeo.ViewModels.CataLog.Products;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using ShopHeo.Data.Entities;

namespace ShopHeo.Application.Catalog.Products
{
    public class PublicProductService : IPublicProductService
    {
        private readonly HshopDBContext context;
        public PublicProductService(HshopDBContext context)
        {
            this.context = context;
        }

        public Task<List<ProductViewModel>> GetAll(string languageId)
        {
            throw new NotImplementedException();
        }

        public async Task<PageResult<ProductViewModel>> GetAllByCategoryId(string languageId, PagingGetManagerProductBase request)
        {
            //query
            var query = from p in this.context.Products
                        join pt in this.context.ProductTranslations on p.Id equals pt.ProductId
                        join pic in this.context.ProductInCategories on p.Id equals pic.ProductId
                        join c in this.context.Categories on pic.CategoryId equals c.Id
                        select new { p, pt, pic, c };
            //filter
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.pt.Name.Contains(request.Keyword));
            }
            if (request.CategoryId != null && request.CategoryId != 0)
            {
                query = query.Where(x => x.pic.CategoryId == request.CategoryId);
            }
            //paging
            int totalrow = await query.CountAsync();
            var data = await query.Skip((request.pageIndex - 1) * request.pageSize)
                .Take(request.pageSize)
                .Select(x => new ProductViewModel()
                {
                    Id = x.p.Id,
                    Name = x.pt.Name,
                    DateCreated = x.p.DateCreated,
                    Description = x.pt.Description,
                    Details = x.pt.Details,
                    LanguageId = x.pt.LanguageId,
                    OriginalPrice = x.p.OriginalPrice,
                    Price = x.p.Price,
                    SeoAlias = x.pt.SeoAlias,
                    SeoDescription = x.pt.SeoDescription,
                    SeoTitle = x.pt.SeoTitle,
                    Stock = x.p.Stock,
                    ViewCount = x.p.ViewCount
                }).ToListAsync();
            //select and total row
            var pageResult = new PageResult<ProductViewModel>()
            {
                TotalRecords = totalrow,
                Items = data
            };
            return pageResult;
        }

        public Task<PageResult<ProductViewModel>> GetAllByCategoryId(string languageId, PagingGetPublicProductBase request)
        {
            throw new NotImplementedException();
        }
    }
}
