using ShopHeo.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopHeo.ViewModels.CataLog.Products
{
    public class PagingGetPublicProductBase : PagingRequestBase
    {
        public string languageId { get; set; }
        public int CategoryID { get; set; }
    }
}
