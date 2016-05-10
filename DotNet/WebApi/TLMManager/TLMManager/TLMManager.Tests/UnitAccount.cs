using Microsoft.VisualStudio.TestTools.UnitTesting;
using TLMManager.Controller;
using TLMManager.Entity;
using TLMManager.Service;

namespace TLMManager.Tests
{
    [TestClass]
    public class UnitAccount
    {
        [TestMethod]
        public void Login()
        {
            ModelInject.Init();//ioc
            var unit = new AccountController();
            var login = new LogOnModel()
            {
                UserName = "100100",
                PassWord = "1",
                IsRemenberMe = true
            };
            var result = unit.Login(login);
            Assert.IsNotNull(result);
        }
    }
}
