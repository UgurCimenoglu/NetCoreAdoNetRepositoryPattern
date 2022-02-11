using AdoNet.DAL.Abstract;
using AdoNet.DAL.Abstract.UnitOfWorkInterfaces;
using AdoNet.DAL.Concrete.AdoNet.UnitOfWorkSqlServer;
using AdoNet.Entities.Base;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace AdoNet.DAL.Concrete.AdoNet.Repository
{
    public class Repository<T> : IGenericRepository<T> where T : IEntity
    {

        SqlConnection _context;
        private readonly IConfiguration _configuration;
        public Repository(IConfiguration configuration)
        {
            _configuration = configuration;
            _context = new SqlConnection(_configuration.GetConnectionString("SqlServer"));
            _context.Open();

        }
        protected SqlCommand CreateCommand(string procedure)
        {
            return new SqlCommand(procedure, _context);
        }

        public T Add(T entity, string Procedure)
        {
            using (var cmd = CreateCommand(Procedure))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                foreach (var item in entity.GetType().GetProperties())
                {
                    cmd.Parameters.AddWithValue(item.Name, item.GetValue(entity, null));
                }
                cmd.ExecuteNonQuery();
                return entity;
            }
        }

        public bool Delete(int id, string Procedure)
        {
            throw new NotImplementedException();
        }

        public bool Delete(T entity, string Procedure)
        {
            throw new NotImplementedException();
        }

        public T Find(int id, string Procedure)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll(string Procedure)
        {
            throw new NotImplementedException();
        }

        public T Update(T entity, string Procedure)
        {
            throw new NotImplementedException();
        }

    }
}
