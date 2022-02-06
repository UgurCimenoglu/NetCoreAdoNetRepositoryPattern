using AdoNetDeneme.DAL.Abstract;
using AdoNetDeneme.Entities.Entites;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Data;

namespace AdoNetDeneme.DAL.Concrete.AdoNet.Repository
{
    public class UserRepository : Repository, IUserRepository
    {

        public UserRepository(SqlConnection context, SqlTransaction transaction)
        {
            _context = context;
            _transaction = transaction;
        }

        public User Add(User entity)
        {
            var cmd = CreateCommand("addUser");
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

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public User Find(int id)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
