using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace AdoNetDeneme.DAL.Concrete.AdoNet.Repository
{
    public abstract class Repository
    {
        protected SqlConnection _context;
        protected SqlTransaction _transaction;

        protected SqlCommand CreateCommand(string procedure)
        {
            return new SqlCommand(procedure, _context, _transaction);
        }
    }
}
