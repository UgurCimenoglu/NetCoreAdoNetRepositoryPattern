using AdoNetDeneme.DAL.Abstract;
using AdoNetDeneme.Entities.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace AdoNetDeneme.DAL.Concrete.AdoNet.Repository
{
    public class Repository<T> : IGenericRepository<T> where T : IEntity
    {
        protected SqlConnection _context;

        public Repository(SqlConnection context)
        {
            _context = context;
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
                //cmd.Parameters.AddWithValue(@"FirstName", entity.FirstName);
                //cmd.Parameters.AddWithValue(@"LastName", entity.LastName);
                //cmd.Parameters.AddWithValue(@"Email", entity.Email);
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
