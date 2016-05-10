using Microsoft.VisualStudio.TestTools.UnitTesting;
using TLMManager.Controller;
using TLMManager.Entity;
using TLMManager.Service;

namespace TLMManager.Tests
{
    [TestClass]
    public class UnitMessage
    {
        public UnitMessage()
        {
            ModelInject.Init();//ioc
        }

        [TestMethod]
        public void Add()
        {
            var unit = new MessageController();
            unit.Add("tom", "lily", "123");
        }

        [TestMethod]
        public void GetList()
        {
            const string fromuser = "100100";
            const string touser = "100100";
            var unit = new MessageController();
            unit.GetMessageList(fromuser, touser);
        }
    }
}
