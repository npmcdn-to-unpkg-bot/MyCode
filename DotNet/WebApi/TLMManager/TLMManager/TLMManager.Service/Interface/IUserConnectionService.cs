using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TLMManager.Entity;

namespace TLMManager.Service.Interface
{
    public interface IUserConnectionService
    {
        UserConnection Get(string username);

        bool Add(UserConnection conn);

        bool Update(UserConnection conn);

        IList<UserConnection> GetList();

        IList<UserConnection> GetList(Expression<Func<UserConnection, bool>> factor);
    }
}
