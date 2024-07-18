using ShopHeo.Application.Catalog.Products.Dtos;
using ShopHeo.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShopHeo.Application.Catalog
{
    interface IManageProductService
    {
        Task<int> Create(ProductCreatedRequest request);
        Task<int> Update(ProductUpdateRequest request);
        Task<int> Delete(int productId);
        Task<int> UpdateStock(int productId, int quantity);

        PageResult<ProductViewModel> GetAll();

        PageResult<ProductViewModel> GetAllPaging(PagingGetProductBase requestBase);

    }
}
