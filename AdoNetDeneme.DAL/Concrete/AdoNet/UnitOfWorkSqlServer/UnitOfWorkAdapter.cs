using AdoNetDeneme.DAL.Abstract.UnitOfWorkInterfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace AdoNetDeneme.DAL.Concrete.AdoNet.UnitOfWorkSqlServer
{
    public class UnitOfWorkAdapter : IUnitOfWorkAdapter
    {
        private SqlConnection _context { get; set; }
        private SqlTransaction _transaction { get; set; }
        public IUnitOfWorkRepository Repositories { get; set; }

        public UnitOfWorkAdapter(string connectionString)
        {
            _context = new SqlConnection(connectionString);
            _context.Open();
            _transaction = _context.BeginTransaction();
            Repositories = new UnitOfWorkRepository(_context, _transaction);
        }

        public void Dispose()
        {
            if (_transaction != null)
            {
                _transaction.Dispose();
            }
            if (_context != null)
            {
                _context.Close();
                _context.Dispose();
            }
            Repositories = null;
        }

        public void RollBack()
        {
            _transaction.Rollback();
        }

        public void SaveChanges()
        {
            _transaction.Commit();
        }
    }
}
