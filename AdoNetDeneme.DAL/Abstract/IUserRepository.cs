using AdoNet.Entities.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdoNet.DAL.Abstract
{
    public interface IUserRepository : IGenericRepository<User>
    {
        public bool userCheckEmail(string email, string Procedure = default);
        public User GetByEmail(string email, string Procedure = default);
    }
}
