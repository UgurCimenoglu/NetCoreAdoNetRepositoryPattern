using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Data;
using AdoNet.DAL.Abstract;
using AdoNet.Entities.Entites;
using Microsoft.Extensions.Configuration;

namespace AdoNet.DAL.Concrete.AdoNet.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly IConfiguration _configuration;
        public UserRepository(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        public User GetByEmail(string email, string Procedure = null)
        {
            using (var cmd = CreateCommand(Procedure))
            {
                User user = new User();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(@"Email", email);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    user.Id = Convert.ToInt32(rdr["Id"]);
                    user.FirstName = rdr["FirstName"].ToString();
                    user.LastName = rdr["LastName"].ToString();
                    user.Email = rdr["Email"].ToString();
                    user.PasswordHash = (byte[])rdr["PasswordHash"];
                    user.PasswordSalt = (byte[])rdr["PasswordSalt"];
                    user.Status = Convert.ToBoolean(rdr["Status"]);
                }
                return user;
            }
        }

        public bool userCheckEmail(string email, string Procedure = default)
        {
            using (var cmd = CreateCommand(Procedure))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(@"Email", email);
                var count = (int)cmd.ExecuteScalar();
                return count > 0 ? true : false;
            }
        }
    }
}
