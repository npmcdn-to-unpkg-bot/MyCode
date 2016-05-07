#region 自有namespace
using TLMManager.Core;
using TLMManager.Entity;
using TLMManager.Service.Interface;
using TLMManager.Utils;
#endregion

namespace TLMManager.Service
{
    public class AccountService : DbHelper, IAccountService
    {
        private readonly IDbHelper _db;
        public AccountService()
        {
            _db = DbHelperInject.Inject<IDbHelper>();
        }

        #region IAccountService Members

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="model"></param>
        /// <param name="message"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool Logon(LogOnModel model, out string message, out SystemUser user)
        {
            var isTrue = CheckUserAndPassword(model.UserName, model.PassWord, out message, out user);

            return isTrue;
        }

        /// <summary>
        /// 检查登录用户合法性
        /// </summary>
        /// <param name="empo"></param>
        /// <param name="password"></param>
        /// <param name="message"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        private bool CheckUserAndPassword(string empo, string password, out string message, out SystemUser user)
        {
            var isSuccess = false;
            message = string.Empty;

            user = _db.Find<SystemUser>(o => o.TLM_empno == empo);
            if (user != null)
            {
                string encryptPwd = Md5Encrypt.Md5(password);
                if (user.Password != encryptPwd)
                {
                    message = "用户名或密码错误";
                }
                else
                {
                    isSuccess = true;
                }
            }
            else
            {
                message = "用户名或密码错误";
            }

            return isSuccess;
        }

        #endregion
    }
}
