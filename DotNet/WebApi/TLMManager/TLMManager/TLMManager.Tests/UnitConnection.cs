using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TLMManager.Controller;
using TLMManager.Entity;
using TLMManager.Service;

namespace TLMManager.Tests
{
    [TestClass]
    public class UnitConnection
    {
        public UnitConnection()
        {
            ModelInject.Init();
        }

        [TestMethod]
        public void Add()
        {
            var conn = new UserConnection
            {
                UserName = "10989",
                Avator = "",
                ConnectionId = "",
                Name = "周文淘",
                AddTime = DateTime.Now
            };
            var unit = new UserConnectionController();
            unit.Add(conn);
        }
    }
}
