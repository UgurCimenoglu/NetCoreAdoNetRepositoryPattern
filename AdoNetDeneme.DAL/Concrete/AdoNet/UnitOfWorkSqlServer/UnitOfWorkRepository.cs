using AdoNetDeneme.DAL.Abstract;
using AdoNetDeneme.DAL.Abstract.UnitOfWorkInterfaces;
using AdoNetDeneme.DAL.Concrete.AdoNet.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace AdoNetDeneme.DAL.Concrete.AdoNet.UnitOfWorkSqlServer
{
    public class UnitOfWorkRepository : IUnitOfWorkRepository
    {
        public IUserRepository UserRepository { get; }

        public UnitOfWorkRepository(SqlConnection context, SqlTransaction transaction)
        {
            UserRepository = new UserRepository(context, transaction);
        }
    }
}
