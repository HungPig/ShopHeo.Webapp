using System;
using System.Collections.Generic;
using System.Text;

namespace ShopHeo.Unlitiles
{
    public class HshopException : Exception
    {
        public HshopException()
        {
        }

        public HshopException(string message)
            : base(message)
        {
        }

       public HshopException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
