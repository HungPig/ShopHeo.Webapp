using ShopHeo.Application.Dtos;
using ShopHeo.ViewModels.CataLog.Products;
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
