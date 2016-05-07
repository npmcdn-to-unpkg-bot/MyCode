using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;

using TLMManager.Core;
using TLMManager.Service.Interface;

namespace TLMManager.Service
{
    public class ModelInject
    {
        static IKernel container;

        public static void Init()
        {
            container = new StandardKernel(); //ioc 注册
            DBHelperInject.Init(container);
            AddBindings();
        }

        private static void AddBindings()
        {
            container.Bind<IUserService>().To<UserService>();
            container.Bind<IMessageService>().To<MessageService>();
            container.Bind<IAccountService>().To<AccountService>();
        }

        /// <summary>
        /// 翻转方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Inject<T>()
        {
            return container.Get<T>();
        }
    }
}
