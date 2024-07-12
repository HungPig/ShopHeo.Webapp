using ShopHeo.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopHeo.Application.CataLog.Products.Dtos.Public
{
    public class PublicProductRequest : PagingRequestBase
    {
        public int CategoryID { get; set; }
    }
}
