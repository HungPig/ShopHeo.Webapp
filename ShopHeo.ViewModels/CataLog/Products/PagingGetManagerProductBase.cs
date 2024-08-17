using ShopHeo.ViewModels.Commom;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopHeo.ViewModels.CataLog.Products
{
    public class PagingGetManagerProductBase : PagingRequestBase
    {

        public string Keyword { get; set; }
        public string LanguageId { get; set; }
        public int? CategoryId { get; set; }
    }
}
