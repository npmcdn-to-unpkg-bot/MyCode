using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace TLMManager.Core
{
    internal class DBfactory
    {
        public static TLMContext GetCurrentContext()
        {
            TLMContext _context = CallContext.GetData("TLMContext") as TLMContext;

            if (_context == null)
            {
                _context = new TLMContext();
                _context.Configuration.ValidateOnSaveEnabled = false;
                CallContext.SetData("TLMContext", _context);
            }

            return _context;
        }
    }
}
