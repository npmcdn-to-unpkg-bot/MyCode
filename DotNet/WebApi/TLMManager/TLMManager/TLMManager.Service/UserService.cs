using System.Collections.Generic;
using System.Linq;

#region 自有namespace
using TLMManager.Core;
using TLMManager.Entity;
using TLMManager.Service.Interface;
using TLMManager.Utils;
#endregion
namespace TLMManager.Service
{
    public class UserService : DbHelper, IUserService
    {
        private readonly IDbHelper _db;
        public UserService()
        {
            _db = ModelInject.Inject<IDbHelper>();
        }

        public IDictionary<string, IList<SystemUser>> GetList()
        {
            IList<SystemUser> list = _db.GetList<SystemUser>().ToList();
            var dic = new Dictionary<string, IList<SystemUser>>();

            foreach(var item in list)
            {
                IList<SystemUser> temp = new List<SystemUser>();
                var firstLetter = PinYinHelper.MakeSpellCode(item.Name, SpellOptions.FirstLetterOnly).Substring(0, 1);
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
