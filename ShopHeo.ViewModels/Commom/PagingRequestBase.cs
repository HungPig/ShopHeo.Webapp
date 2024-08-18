using System;
using System.Collections.Generic;
using System.Text;

namespace ShopHeo.ViewModels.Commom
{
    public class PagingRequestBase : RequestBase
    {
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
    }
}
