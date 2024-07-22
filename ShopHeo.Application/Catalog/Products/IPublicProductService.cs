using ShopHeo.Application.Catalog.Products.Dtos;
using ShopHeo.Application.Dtos;
using ShopHeo.ViewModels.CataLog.Products.Manager;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopHeo.Application.Catalog.Products
{
    interface IPublicProductService
    {
        PageResult<ProductViewModel> GetAllByCategoryId(PagingGetManagerProductBase request);
    }
}
