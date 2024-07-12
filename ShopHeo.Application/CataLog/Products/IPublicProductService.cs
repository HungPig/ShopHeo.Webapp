using ShopHeo.Application.CataLog.Products.Dtos.Manage;
using ShopHeo.Application.CataLog.Products.Dtos.Public;
using ShopHeo.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopHeo.Application.CataLog.Products
{
    public interface IPublicProductService
    {
        PagedResult<ProductViewModel> GetAllByCategoryID(PublicProductRequest request);
    }
}
