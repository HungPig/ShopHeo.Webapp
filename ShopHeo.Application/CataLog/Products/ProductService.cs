﻿using Microsoft.EntityFrameworkCore;
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
using ShopHeo.ViewModels.CataLog.ProductsImage;
using static System.Net.Mime.MediaTypeNames;
using ShopHeo.ViewModels.Commom;

namespace ShopHeo.Application.Catalog.Products
{
    public class ProductService : IProductService
    {
        private readonly string USER_CONTENT_FOLDER_NAME = "user-content";
        private readonly IStorageService storageService;
        private readonly HshopDBContext context;
        public ProductService(HshopDBContext context, IStorageService storageService)
        {
            this.context = context;
            this.storageService = storageService;
        }

        public async Task<int> AddImage(int productId, ProductImageCreatedRequest request)
        {
            var productImage = new ProductImage()
            {
                ProductId = productId,
                Caption = request.Caption,
                DateCreated = DateTime.Now,
                FileSize = request.ImageFile.Length,
                ImagePath = await this.SaveFile(request.ImageFile),
                IsDefault = request.IsDefault,
                SortOrder = request.SortOrder
            };
            if(request.ImageFile != null)
            {
                productImage.ImagePath = await this.SaveFile(request.ImageFile);
                productImage.FileSize = request.ImageFile.Length;
            }
            this.context.ProductImages.Add(productImage);
            await this.context.SaveChangesAsync();
            return productImage.Id;
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

        public async Task<List<ProductImageViewModel>> GetListImages(int productId)
        {
            return await this.context.ProductImages.Where(i => i.ProductId == productId)
                .Select(i => new ProductImageViewModel()
                {
                    Id = i.Id,
                    Caption = i.Caption,
                    DateCreated = i.DateCreated,
                    FileSize = i.FileSize,
                    ImagePath = i.ImagePath,
                    IsDefault = i.IsDefault,
                    SortOrder = i.SortOrder
                }).ToListAsync();
        }

        public async Task<PageResult<ProductViewModel>> GetAllPaging(PagingGetManagerProductBase request)
        {
            //1. Select join
            var query = from p in this.context.Products
                        join pt in this.context.ProductTranslations on p.Id equals pt.ProductId
                        join pic in this.context.ProductInCategories on p.Id equals pic.ProductId into ppic
                        from pic in ppic.DefaultIfEmpty()
                        join c in this.context.Categories on pic.CategoryId equals c.Id into picc
                        from c in picc.DefaultIfEmpty()
                        join pi in this.context.ProductImages on p.Id equals pi.ProductId into ppi
                        from pi in ppi.DefaultIfEmpty()
                        where pt.LanguageId == request.LanguageId && pi.IsDefault == true
                        select new { p, pt, pic, pi };
            //2. filter
            if (!string.IsNullOrEmpty(request.Keyword))
                query = query.Where(x => x.pt.Name.Contains(request.Keyword));

            if (request.CategoryId != null && request.CategoryId != 0)
            {
                query = query.Where(p => p.pic.CategoryId == request.CategoryId);
            }

            //3. Paging
            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.pageIndex - 1) * request.pageSize)
                .Take(request.pageSize)
                .Select(x => new ProductViewModel()
                {
                    Id = x.p.Id,
                    Name = x.pt.Name,
                    DateCreated = x.p.DateCreated,
                    Description = x.pt.Description,
                    Details = x.pt.Details,
                    LanguageId = x.pt.LanguageId,
                    OriginalPrice = x.p.OriginalPrice,
                    Price = x.p.Price,
                    SeoAlias = x.pt.SeoAlias,
                    SeoDescription = x.pt.SeoDescription,
                    SeoTitle = x.pt.SeoTitle,
                    Stock = x.p.Stock,
                    ViewCount = x.p.ViewCount,
                    ThumbnailImage = x.pi.ImagePath
                }).ToListAsync();

            //4. Select and projection
            var pagedResult = new PageResult<ProductViewModel>()
            {
                TotalRecords = totalRow,
                PageSize = request.pageSize,
                PageIndex = request.pageIndex,
                Items = data
            };
            return pagedResult;

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

        public async Task<int> RemoveImage(int imageId)
        {
            var productimage = await this.context.ProductImages.FindAsync(imageId);
            if (productimage == null)
            {
                throw new HshopExceptions($"Cannot find a product image with id: {imageId}");
            }
            this.context.ProductImages.Remove(productimage);
            return await this.context.SaveChangesAsync();
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

        public async Task<int> UpdateImage(int imageId, ProductImageUpdateRequest product)
        {
            var productImage = await this.context.ProductImages.FindAsync(imageId);
            if (productImage == null)
            {
                throw new HshopExceptions($"Cannot find a product image with id: {imageId}");
            }
            if (product.ImageFile != null)
            {
                productImage.FileSize = product.ImageFile.Length;
                productImage.ImagePath = await this.SaveFile(product.ImageFile);
            }
            this.context.ProductImages.Update(productImage);
            return await this.context.SaveChangesAsync();
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

        public async Task<ProductImageViewModel> GetImageId(int ImageId)
        {
            var image = await this.context.ProductImages.FindAsync(ImageId);
            if (image == null)
            {
                throw new HshopExceptions($"Cannot find a image with id: {ImageId}");
            }
            var viewModel = new ProductImageViewModel()
            {
                Caption = image.Caption,
                DateCreated = image.DateCreated,
                FileSize = image.FileSize,
                Id = image.Id,
                ImagePath = image.ImagePath,
                IsDefault = image.IsDefault,
                ProductId = image.ProductId,
                SortOrder = image.SortOrder
            };
            return viewModel;
        }

        public async Task<PageResult<ProductViewModel>> GetAllByCategoryId(string languageId, PagingGetPublicProductBase request)
        {
            //1. Select join
            var query = from p in this.context.Products
                        join pt in this.context.ProductTranslations on p.Id equals pt.ProductId
                        join pic in this.context.ProductInCategories on p.Id equals pic.ProductId
                        join c in this.context.Categories on pic.CategoryId equals c.Id
                        where pt.LanguageId == languageId
                        select new { p, pt, pic };
            //2. filter
            if (request.CategoryId > 0)
            {
                query = query.Where(x => x.pic.CategoryId == request.CategoryId);
            }
            //3. Paging
            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.pageIndex - 1) * request.pageSize)
                .Take(request.pageSize)
                .Select(x => new ProductViewModel()
                {
                    Id = x.p.Id,
                    Name = x.pt.Name,
                    DateCreated = x.p.DateCreated,
                    Description = x.pt.Description,
                    Details = x.pt.Details,
                    LanguageId = x.pt.LanguageId,
                    OriginalPrice = x.p.OriginalPrice,
                    Price = x.p.Price,
                    SeoAlias = x.pt.SeoAlias,
                    SeoDescription = x.pt.SeoDescription,
                    SeoTitle = x.pt.SeoTitle,
                    Stock = x.p.Stock,
                    ViewCount = x.p.ViewCount,
                }).ToListAsync();

            //4. Select and projection
            var pagedResult = new PageResult<ProductViewModel>()
            {
                TotalRecords = totalRow,
                PageSize = request.pageSize,
                PageIndex = request.pageIndex,
                Items = data
            };
            return pagedResult;
        }
    }
}
