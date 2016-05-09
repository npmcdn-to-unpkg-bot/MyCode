using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using TLMManager.Controller;
using TLMManager.Service;

namespace TLMManager.Tests
{
    [TestClass]
    public class UnitUser
    {
        [TestMethod]
        public void GetList()
        {
            ModelInject.Init();//ioc
            var unit = new UserController();

            var list = unit.GetList();
            Assert.AreNotEqual(list.Count(), 0);
        }
    }
}
