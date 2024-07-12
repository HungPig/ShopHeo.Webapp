using System;
using System.Collections.Generic;
using System.Text;

namespace ShopHeo.Application.Dtos
{
    public class PagingRequestBase
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
