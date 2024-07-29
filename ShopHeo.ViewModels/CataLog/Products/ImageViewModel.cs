using System;
using System.Collections.Generic;
using System.Text;

namespace ShopHeo.ViewModels.CataLog.Products
{
    public class ImageViewModel
    {
        public int Id { set; get; }
        public string ImagePath { set; get; }
        public bool IsDefault { set; get; }
        public int FileSize { set; get; }
    }
}
