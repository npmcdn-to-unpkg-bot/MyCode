using Microsoft.VisualStudio.TestTools.UnitTesting;
using TLMManager.Controller;
using TLMManager.Service;

namespace TLMManager.Tests
{
    [TestClass]
    public class UnitMessage
    {
        [TestMethod]
        public void Add()
        {
            ModelInject.Init();//ioc
            var unit = new MessageController();
            unit.Add("tom", "lily", "123");
        }
    }
}
