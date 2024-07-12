using System;
using System.Collections.Generic;
using System.Text;

namespace ShopHeo.Application.Dtos
{
    public interface PagedResult<T>
    {
        public int TotalRecord { get; set; }
        public List<T> Items { get; set; }
    }
}
