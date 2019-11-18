using System;

namespace GameStore.BLL.Exceptions
{
   public class ItemNotFoundException : Exception
    {
        public ItemNotFoundException() : base() {}
        public ItemNotFoundException(string message) : base(message) { }
    }
}
