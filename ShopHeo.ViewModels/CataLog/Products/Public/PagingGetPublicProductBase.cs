﻿using ShopHeo.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopHeo.ViewModels.CataLog.Products.Public
{
    public class PagingGetPublicProductBase : PagingRequestBase
    {
        public int CategoryID { get; set; }
    }
}
