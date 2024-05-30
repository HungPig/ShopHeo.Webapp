﻿using ShopHeo.Data.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopHeo.Data.Entities
{
    public class Transaction
    {
        public int Id { get; set; }
        public DateTime TransactionDate { get; set; }
        public string ExtenalTransactionID { get; set; }
        public decimal Amount { get; set; }
        public decimal Fee { get; set; }
        public string Result {  get; set; }
        public string Message { get; set; }
        public ProductTranslation Status { get; set; }
        public string Provider { get; set; }
    }
}
