using Ninject;

namespace TLMManager.Core
{
    public class DbHelperInject
    {
        private static IKernel _container;

        public static void Init(IKernel kernel)
        {
            _container = kernel;
            _container.Bind<IDbHelper>().To<DbHelper>();
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
