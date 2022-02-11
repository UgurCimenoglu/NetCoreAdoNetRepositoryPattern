using AdoNet.Entities.Base;
using AdoNet.Entities.Dtos;
using AdoNet.Entities.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdoNet.BLL.Abstract
{
    public interface IAuthService : IBllBase<User>
    {
        Response Register(DtoUserForRegister userForRegisterDto);
        Response<DtoUserToken> Login(DtoUserLogin login);
        //IResponse UserExists(string email);
        //IResponse<AccessToken> CreateAccessToken(User user)
    }
}
