using System;
using System.Collections.Generic;
using System.Text;

namespace ShopHeo.ViewModels.Commom
{
    public class PageResult<T> : PageResultBase
    {
        public List<T> Items { get; set; }
      
    }
}
