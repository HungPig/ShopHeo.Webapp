using Microsoft.EntityFrameworkCore;
using ShopHeo.Application.Dtos;
using ShopHeo.Data.EF;
using ShopHeo.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Threading.Tasks.Dataflow;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Net.Http.Headers;
using ShopHeo.Application.Common;
using ShopHeo.Untitiles.Exceptions;
using ShopHeo.ViewModels.CataLog.Products;

namespace ShopHeo.Application.Catalog.Products
{
    public class ManageProductService : IManageProductService
    {
        private readonly string USER_CONTENT_FOLDER_NAME = "user-content";
        private readonly IStorageService storageService;
        private readonly HshopDBContext context;
        public ManageProductService(HshopDBContext context, IStorageService storageService)
        {
            this.context = context;
            this.storageService = storageService;
        }

        public async Task<int> AddImage(int productId, List<IFormFile> formFiles)
        {
            throw new NotImplementedException();
        }

        public async Task AddViewCount(int productId)
        {
            var product = await this.context.Products.FindAsync(productId);
            if (product == null)
            {
                throw new HshopExceptions($"Cannot find a product: {productId}");
            }
            product.ViewCount += 1;
            await this.context.SaveChangesAsync();
        }

        public async Task<int> Create(ProductCreatedRequest request)
        {
            var product = new Product()
            {
                Price = request.Price,
                OriginalPrice = request.OriginalPrice,
                Stock = request.Stock,
                ViewCount = 0,
                DateCreated = DateTime.Now,
                ProductTranslations = new List<ProductTranslation>()
                {
                     new ProductTranslation()
                     {
                     Name = request.Name,
                     Description = request.Description,
                     Details = request.Details,
                     SeoAlias = request.SeoAlias,
                     SeoDescription = request.SeoDescription,
                     SeoTitle = request.SeoTitle,
                     LanguageId = request.LanguageId
                     }
                }
            };
            // save image
            if(request.ThumbnailFile != null)
            {
                product.ProductImages = new List<ProductImage>()
                {
                    new ProductImage()
                    {
                        Caption = "Thumbnail image",
                        DateCreated = DateTime.Now,
                        FileSize = request.ThumbnailFile.Length,
                        ImagePath = await this.SaveFile(request.ThumbnailFile),
                        IsDefault = true,
                        SortOrder = 1
                    }
                };
            }
            this.context.Products.Add(product);
            await this.context.SaveChangesAsync();
            return product.Id;
        }

        public async Task<int> Delete(int productId)
        {
            var product = await this.context.Products.FindAsync(productId);
            if (product == null)
            {
                throw new HshopExceptions($"Cannot find a product: {productId}");
            }
            var images = this.context.ProductImages.Where(i => i.ProductId == productId);
            foreach (var image in images)
            {
                await this.storageService.DeleteFileAsync(image.ImagePath);
            }
            this.context.Products.Remove(product);
            return await this.context.SaveChangesAsync();
        }

        public Task<ImageViewModel> GetAllImage(int productId)
        {
            throw new NotImplementedException();
        }

        public async Task<PageResult<ProductViewModel>> GetAllPaging(PagingGetManagerProductBase request)
        {
            //query
            var query = from p in this.context.Products
                        join pt in this.context.ProductTranslations on p.Id equals pt.ProductId
                        join pic in this.context.ProductInCategories on p.Id equals pic.ProductId
                        join c in this.context.Categories on pic.CategoryId equals c.Id
                        select new { p, pt, pic, c };
            //filter
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.pt.Name.Contains(request.Keyword));
            }
            if (request.CategoryId != null && request.CategoryId != 0)
            {
                query = query.Where(x => x.pic.CategoryId == request.CategoryId);
            }
            //paging
            int totalrow = await query.CountAsync();
            var data = await query.Skip((request.pageIndex - 1) * request.pageSize)
                .Take(request.pageSize)
                .Select(x => new ProductViewModel()
                {
                    Id = x.p.Id,
                    Name = x.pt.Name,
                    DateCreated = x.p.DateCreated,
                    OriginalPrice = x.p.OriginalPrice,
                    Price = x.p.Price,
                    SeoAlias = x.pt.SeoAlias,
                    SeoDescription = x.pt.SeoDescription,
                    SeoTitle = x.pt.SeoTitle,
                    Stock = x.p.Stock,
                    ViewCount = x.p.ViewCount
                }).ToListAsync();
            //select and total row
            var pageResult = new PageResult<ProductViewModel>()
            {
                TotalRecords = totalrow,
                Items = data
            };
            return pageResult;

        }

        public async Task<ProductViewModel> GetById(int productId, string languageId)
        {
            var product = await this.context.Products.FindAsync(productId);
            var productTranslation = await this.context.ProductTranslations.FirstOrDefaultAsync(x => x.ProductId == productId
            && x.LanguageId == languageId);

            var categories = await (from c in this.context.Categories
                                    join ct in this.context.CategoryTranslations on c.Id equals ct.CategoryId
                                    join pic in this.context.ProductInCategories on c.Id equals pic.CategoryId
                                    where pic.ProductId == productId && ct.LanguageId == languageId
                                    select ct.Name).ToListAsync();

            var image = await this.context.ProductImages.Where(x => x.ProductId == productId && x.IsDefault == true).FirstOrDefaultAsync();

            var productViewModel = new ProductViewModel()
            {
                Id = product.Id,
                DateCreated = product.DateCreated,
                Description = productTranslation != null ? productTranslation.Description : null,
                LanguageId = productTranslation.LanguageId,
                Details = productTranslation != null ? productTranslation.Details : null,
                Name = productTranslation != null ? productTranslation.Name : null,
                OriginalPrice = product.OriginalPrice,
                Price = product.Price,
                SeoAlias = productTranslation != null ? productTranslation.SeoAlias : null,
                SeoDescription = productTranslation != null ? productTranslation.SeoDescription : null,
                SeoTitle = productTranslation != null ? productTranslation.SeoTitle : null,
                Stock = product.Stock,
                ViewCount = product.ViewCount,              
            };
            return productViewModel;
        }

        public Task<int> RemoveImage(int imageId)
        {
            throw new NotImplementedException();
        }

        // cap nhap san pham
        public async Task<int> Update(ProductUpdateRequest request)
        {
            var product = await this.context.Products.FindAsync(request.Id);// tim toi id
            var productTranslation = await this.context.ProductTranslations.FirstOrDefaultAsync(x => x.ProductId == request.Id && x.LanguageId == request.LanguageId);
            if (product == null || productTranslation == null)
            {
                throw new HshopExceptions($"Cannot find a product with id: {request.Id}");
            }
            // update product
            productTranslation.Name = request.Name;
            productTranslation.SeoAlias = request.SeoAlias;
            productTranslation.SeoDescription = request.SeoDescription;
            productTranslation.SeoTitle = request.SeoTitle;
            productTranslation.Details = request.Details;
            productTranslation.Description = request.Description;
            if (request.ThumbnailFile != null)
            {
                var thumbnailImage = await this.context.ProductImages.FirstOrDefaultAsync(i => i.ProductId == request.Id && i.IsDefault == true);
                if(thumbnailImage != null)
                {
                    thumbnailImage.FileSize = request.ThumbnailFile.Length;
                    thumbnailImage.ImagePath = await this.SaveFile(request.ThumbnailFile);
                    this.context.ProductImages.Update(thumbnailImage);
                }
                product.ProductImages = new List<ProductImage>()
                {
                    new ProductImage()
                    {
                        Caption = "Thumbnail image",
                        DateCreated = DateTime.Now,
                        FileSize = request.ThumbnailFile.Length,
                        ImagePath = await this.SaveFile(request.ThumbnailFile),
                        IsDefault = true,
                        SortOrder = 1
                    }
                };
            }
            return await this.context.SaveChangesAsync();
        }

        public Task<int> UpdateImage(int imageId, string caption, bool isDefault)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdatePrice(int productId, decimal newPrice)
        {
            //tim san pham
            var product = await this.context.Products.FindAsync(productId);
            if (product == null)
            {
                throw new HshopExceptions($"Cannot find a product with id: {productId}");
            }
            product.Price = newPrice;
            return await this.context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateStock(int productId, int add_quantity)
        {
            // update so luong
            var product = await this.context.Products.FindAsync(productId);
            if (product == null)
            {
                throw new HshopExceptions($"Cannot find a product with id: {productId}");
            }
            product.Stock += add_quantity;
            return await this.context.SaveChangesAsync() > 0;
        }
        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await this.storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return "/" + USER_CONTENT_FOLDER_NAME + "/" + fileName;
        }
    }
}
