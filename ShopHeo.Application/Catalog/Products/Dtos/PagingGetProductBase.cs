using System;
using System.Collections.Generic;
using System.Text;
using ShopHeo.Application.Dtos;

namespace ShopHeo.Application.Catalog.Products.Dtos
{
    public class PagingGetProductBase : PagingRequestBase
    {
        public string Keyword { get; set; }
        public List<int> CategoryIds { get; set; }
    }
}
