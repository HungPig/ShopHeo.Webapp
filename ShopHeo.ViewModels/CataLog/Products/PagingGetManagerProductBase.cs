using System;
using System.Collections.Generic;
using System.Text;
using ShopHeo.Application.Dtos;

namespace ShopHeo.ViewModels.CataLog.Products
{
    public class PagingGetManagerProductBase : PagingRequestBase
    {
        public string Keyword { get; set; }
        public string LanguageID { get; set; }
        public int? CategoryId { get; set; }
    }
}
