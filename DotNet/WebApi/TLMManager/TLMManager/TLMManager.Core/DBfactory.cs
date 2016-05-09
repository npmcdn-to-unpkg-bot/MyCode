using System.Runtime.Remoting.Messaging;

namespace TLMManager.Core
{
    internal class Dbfactory
    {
        public static TLMContext GetCurrentContext()
        {
            var context = CallContext.GetData("TLMContext") as TLMContext;

            if (context != null) return context;
            context = new TLMContext();
            context.Configuration.ValidateOnSaveEnabled = false;
            CallContext.SetData("TLMContext", context);

            return context;
        }
    }
}
