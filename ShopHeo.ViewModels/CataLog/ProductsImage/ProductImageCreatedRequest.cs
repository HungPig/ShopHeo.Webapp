using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopHeo.ViewModels.CataLog.ProductsImage
{
    public class ProductImageCreatedRequest
    {
        public int ProductId { get; set; }

        public string ImagePath { get; set; }

        public string Caption { get; set; }

        public bool IsDefault { get; set; }

        public int SortOrder { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}
