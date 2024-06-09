using System;
using System.Collections.Generic;
using System.Text;

namespace ShopHeo.Data.Entities
{
    public class ProductTranslation
    {
        public int ID { get; set; }
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Details { get; set; }
        public string SeoDesciption { get; set; }
        public string SeoTitle { get; set; }
        public string LangueId { get; set; }
    }
}
