using System;
using System.Collections.Generic;
using System.Text;

namespace GameStore.BLL.Exceptions
{
   public class ItemNotFoundException : Exception
    {
        public ItemNotFoundException() : base() {}
        public ItemNotFoundException(string message) : base(message) { }
    }
}
