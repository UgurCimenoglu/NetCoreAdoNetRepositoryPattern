using AdoNetDeneme.DAL.Abstract.UnitOfWorkInterfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;


namespace AdoNetDeneme.DAL.Concrete.AdoNet.UnitOfWorkSqlServer
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IConfiguration _configuration;

        public UnitOfWork(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IUnitOfWorkAdapter Create()
        {
            var connectionString = _configuration.GetConnectionString("SqlServer");
            return new UnitOfWorkAdapter(connectionString);
        }
    }
}
