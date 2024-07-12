using ShopHeo.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopHeo.Application.CataLog.Products.Dtos.Manage
{
    public class GetProductPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
        public List<int> CategoryID { get; set; }
    }
}
