
using ShopHeo.Application.Catalog.Products.Dtos;
using ShopHeo.Application.Dtos;
using ShopHeo.ViewModels.CataLog.Products.Manager;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShopHeo.Application.Catalog.Products
{
    public interface IManageProductService
    {
        Task<int> Create(ProductCreatedRequest request);
        Task<int> Update(ProductUpdateRequest request);
        Task<int> Delete(int productId);
        Task<bool> UpdateStock(int productId, int quantity);
        Task<bool> UpdatePrice(int productId, decimal newPrice);

        Task AddViewCount(int productId);
        Task<PageResult<ProductViewModel>> GetAllPaging(PagingGetManagerProductBase requestBase);

    }
}
