using ShopHeo.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopHeo.ViewModels.CataLog.Products
{
    public class PagingGetPublicProductBase : PagingRequestBase
    {
        public int CategoryId { get; set; }
    }
}
