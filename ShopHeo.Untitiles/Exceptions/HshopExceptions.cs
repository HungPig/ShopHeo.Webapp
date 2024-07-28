using System;

namespace ShopHeo.Untitiles.Exceptions
{
    public class HshopExceptions : Exception
    {
        public HshopExceptions()
        {
        }

        public HshopExceptions(string message)
            : base(message)
        {
        }

        public HshopExceptions(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
