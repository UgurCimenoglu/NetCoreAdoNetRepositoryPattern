using AdoNet.DAL.Abstract.UnitOfWorkInterfaces;
using AdoNetDeneme.DAL.Abstract;
using AdoNetDeneme.DAL.Concrete.AdoNet.Repository;
using AdoNetDeneme.Entities.Base;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace AdoNet.DAL.Concrete.AdoNet.UnitOfWorkSqlServer
{
    public class UnitOfWorks : IUnitOfWorks 
    {
        private readonly IConfiguration _configuration;
        private SqlConnection _context { get; set; }
        private SqlTransaction _transaction { get; set; }
        bool _dispose;

        public UnitOfWorks(IConfiguration configuration)
        {
            _configuration = configuration;
            _context = new SqlConnection(_configuration.GetConnectionString("SqlServer"));
            _context.Open();
        }


        public bool BeginTransaction()
        {
            try
            {
                _transaction = _context.BeginTransaction();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this._dispose)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                this._dispose = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IGenericRepository<T> GetGenericRepository<T>() where T : IEntity
        {
            return new Repository<T>(_context);
        }

        public bool RollBackTransaction()
        {
            try
            {
                _transaction.Rollback();
                _transaction = null;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void SaveChanges()
        {
            _transaction.Commit();
        }
    }
}
