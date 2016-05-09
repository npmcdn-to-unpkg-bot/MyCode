using Ninject;

using TLMManager.Core;
using TLMManager.Service.Interface;

namespace TLMManager.Service
{
    public class ModelInject
    {
        private static IKernel _container;

        public static void Init()
        {
            _container = new StandardKernel(); //ioc 注册
            DBHelperInject.Init(_container);
            AddBindings();
        }

        private static void AddBindings()
        {
            _container.Bind<IUserService>().To<UserService>();
            _container.Bind<IMessageService>().To<MessageService>();
            _container.Bind<IAccountService>().To<AccountService>();
        }

        /// <summary>
        /// 翻转方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Inject<T>()
        {
            return _container.Get<T>();
        }
    }
}
