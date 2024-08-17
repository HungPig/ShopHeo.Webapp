using System;
using System.Collections.Generic;
using System.Text;

namespace ShopHeo.ViewModels.Commom
{
    public class PageResult<T>
    {
        public List<T> Items { get; set; }
        public int TotalRecords { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
