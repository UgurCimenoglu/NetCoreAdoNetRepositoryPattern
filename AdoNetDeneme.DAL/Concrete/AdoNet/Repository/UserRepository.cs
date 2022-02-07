using AdoNetDeneme.DAL.Abstract;
using AdoNetDeneme.Entities.Entites;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Data;

namespace AdoNetDeneme.DAL.Concrete.AdoNet.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(SqlConnection context) : base(context)
        {

        }
    }
}
