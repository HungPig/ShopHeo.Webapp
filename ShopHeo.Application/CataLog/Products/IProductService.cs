
using Microsoft.AspNetCore.Http;
using ShopHeo.ViewModels.CataLog.Products;
using ShopHeo.ViewModels.CataLog.ProductsImage;
using ShopHeo.ViewModels.Commom;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShopHeo.Application.Catalog.Products
{
    public interface IProductService
    {
        Task<int> Create(ProductCreatedRequest request);
        Task<int> Update(ProductUpdateRequest request);
        Task<int> Delete(int productId);
        Task<bool> UpdateStock(int productId, int quantity);
        Task<bool> UpdatePrice(int productId, decimal newPrice);
        Task<ProductViewModel> GetById(int productId, string languageId);
        Task AddViewCount(int productId);
        Task<PageResult<ProductViewModel>> GetAllPaging(PagingGetManagerProductBase requestBase);
        // image
        Task<int> AddImage(int productId, ProductImageCreatedRequest product);
        Task<int> RemoveImage(int imageId);
        Task<int> UpdateImage(int imageId, ProductImageUpdateRequest product);
        Task<List<ProductImageViewModel>> GetListImages(int productId);
        Task<ProductImageViewModel> GetImageId(int ImageId);

        Task<PageResult<ProductViewModel>> GetAllByCategoryId(string languageId, PagingGetPublicProductBase request);

    }
}
