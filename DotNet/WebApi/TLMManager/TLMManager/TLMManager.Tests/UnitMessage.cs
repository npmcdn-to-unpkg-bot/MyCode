using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Http;

using TLMManager.Controller;
using TLMManager.Service;

namespace TLMManager.Tests
{
    [TestClass]
    public class UnitMessage
    {
        public UnitMessage()
        {
              
        }



        [TestMethod]
        public void Add()
        {
            ModelInject.Init();//ioc
            MessageController unit = new MessageController();
            unit.Add("tom", "lily", "123");
        }
    }
}
