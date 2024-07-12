using ShopHeo.Application.CataLog.Products.Dtos.Manage;
using ShopHeo.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShopHeo.Application.CataLog.Products
{
    public interface IManageProductService
    {
        //Phan Nay ADMIN
        Task<int> Create(ProductCreateRequest request);

        Task<int> Update(ProductEditRequest request);

        Task<int> UpdatePrice(int ProductID, decimal newPrice);

        Task<bool> UpdateStock(int ProductID, int addedQuantaliy);
        Task AddViewCount(int ProductID);
        Task UpdateViewCount(int ProductID);

        Task<int> Delete(int ProductID);

        Task<List<ProductViewModel>> GetAll();

        Task<PagedResult<ProductViewModel>> GetALLPagings(GetProductPagingRequest request);
    }
}
