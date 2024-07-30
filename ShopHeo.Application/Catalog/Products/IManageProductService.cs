
using Microsoft.AspNetCore.Http;
using ShopHeo.Application.Dtos;
using ShopHeo.ViewModels.CataLog.Products;
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
        Task<ProductViewModel> GetById(int productId, string languageId);
        Task AddViewCount(int productId);
        Task<PageResult<ProductViewModel>> GetAllPaging(PagingGetManagerProductBase requestBase);
        Task<int> AddImage(int productId, List<IFormFile> formFiles);
        Task<int> RemoveImage(int imageId);
        Task<int> UpdateImage(int imageId, string caption, bool isDefault);
        Task<ImageViewModel> GetAllImage(int productId);

    }
}
