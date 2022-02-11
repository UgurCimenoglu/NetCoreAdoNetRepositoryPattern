using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using AdoNet.BLL.Abstract;
using AdoNet.DAL.Abstract;
using AdoNet.Entities.Entites;
using System.Data.SqlClient;
using AdoNet.Entities.Base;

namespace AdoNet.BLL.Concrete
{
    public class UserManager : /*BllBase<User>,*/IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserManager(IServiceProvider service) /*: base(service)*/
        {
            _userRepository = service.GetService<IUserRepository>();
        }

        public Response Add(User user)
        {
            try
            {
                _userRepository.Add(user, "addNewUser");
                return new Response
                {
                    Data = null,
                    Message = "Success",
                    StatusCode = StatusCodes.Status200OK
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    Data = null,
                    Message = $"Error: {ex.Message}",
                    StatusCode = StatusCodes.Status406NotAcceptable
                };
            }

        }

        public Response<User> GetByEmail(string email)
        {
            try
            {
                var result = _userRepository.GetByEmail(email, "GetUserByEmail");
                return new Response<User>
                {
                    Data = result,
                    Message = "Success",
                    StatusCode = StatusCodes.Status200OK
                };
            }
            catch (Exception ex)
            {
                return new Response<User>
                {
                    Data = null,
                    Message = $"Error: {ex.Message}",
                    StatusCode = StatusCodes.Status406NotAcceptable
                };
            }
            
        }

        public bool userCheckEmail(string email)
        {
            return _userRepository.userCheckEmail(email, Procedure: "CheckMailCount");
        }


    }
}
