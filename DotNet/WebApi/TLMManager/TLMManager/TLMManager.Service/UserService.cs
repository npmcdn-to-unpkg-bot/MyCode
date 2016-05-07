using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#region 自有namespace
using TLMManager.Core;
using TLMManager.Entity;
using TLMManager.Service.Interface;
using TLMManager.Utils;
#endregion
namespace TLMManager.Service
{
    public class UserService : DBHelper, IUserService
    {
        IDBHelper _db = null;
        public UserService()
        {
            _db = ModelInject.Inject<IDBHelper>();
        }

        public IDictionary<string, IList<SystemUser>> GetList()
        {
            IList<SystemUser> list = null;

            list = _db.GetList<SystemUser>().ToList();
            Dictionary<string, IList<SystemUser>> dic = new Dictionary<string, IList<SystemUser>>();

            foreach(var item in list)
            {
                IList<SystemUser> temp = new List<SystemUser>();
                string firstLetter = PinYinHelper.MakeSpellCode(item.Name, SpellOptions.FirstLetterOnly).Substring(0, 1);
              if (dic.Keys.Contains(firstLetter))
              {
                  dic[firstLetter].Add(item);
              }
              else
              {
                  temp.Add(item);
                  dic.Add(firstLetter, temp);
              }
            }
            return dic;
        }
    }
}
