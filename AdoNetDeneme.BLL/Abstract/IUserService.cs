using AdoNet.Entities.Base;
using AdoNet.Entities.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdoNet.BLL.Abstract
{
    public interface IUserService : IBllBase<User> 
    {
        bool userCheckEmail(string email);
        Response Add(User user);
        Response<User> GetByEmail(string email);
    }
}
