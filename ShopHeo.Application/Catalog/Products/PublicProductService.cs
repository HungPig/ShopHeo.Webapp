using ShopHeo.Application.Catalog.Products.Dtos;
using ShopHeo.Application.Dtos;
using ShopHeo.Data.EF;
using ShopHeo.ViewModels.CataLog.Products.Manager;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopHeo.Application.Catalog.Products
{
    public class PublicProductService : IPublicProductService
    {
        private readonly HshopDBContext context;
        public PublicProductService(HshopDBContext context)
        {
            this.context = context;
        }
        public PageResult<ProductViewModel> GetAllByCategoryId(PagingGetManagerProductBase request)
        {
            throw new NotImplementedException();
        }
    }
}
