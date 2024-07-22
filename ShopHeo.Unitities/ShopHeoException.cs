using System;
using System.Collections.Generic;
using System.Text;

namespace ShopHeo.Unitities
{
    public class ShopHeoException : Exception
    {
        public ShopHeoException()
        {
        }

        public ShopHeoException(string message)
            : base(message)
        {
        }

        public ShopHeoException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
