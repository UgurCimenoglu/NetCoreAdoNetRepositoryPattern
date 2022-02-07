using AdoNet.BLL.Concrete;
using AdoNetDeneme.BLL.Abstract;
using AdoNetDeneme.BLL.Helper;
using AdoNetDeneme.Entities.Base;
using AdoNetDeneme.Entities.Dtos;
using AdoNetDeneme.Entities.Entites;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdoNetDeneme.BLL.Concrete
{
    public class UserManager : BllBase<User, DtoUser>,IUserService
    {
        public UserManager(IServiceProvider service) : base(service)
        {

        }
    }
}
