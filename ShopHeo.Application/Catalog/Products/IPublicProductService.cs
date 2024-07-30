using ShopHeo.Application.Dtos;
using ShopHeo.ViewModels.CataLog.Products;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShopHeo.Application.Catalog.Products
{
    public interface IPublicProductService
    {
        Task<PageResult<ProductViewModel>> GetAllByCategoryId(PagingGetManagerProductBase request);
        Task<List<ProductViewModel>> GetAll();
        
    }
}
