using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;

namespace TLMManager.Core
{
    public class DBHelperInject
    {
        static IKernel container;

        public static void Init(IKernel kernel)
        {
            container = kernel;
            container.Bind<IDBHelper>().To<DBHelper>();
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
