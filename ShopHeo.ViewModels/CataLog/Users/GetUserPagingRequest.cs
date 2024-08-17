
using ShopHeo.ViewModels.Commom;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopHeo.ViewModels.CataLog.Users
{
    public class GetUserPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
    }
}
