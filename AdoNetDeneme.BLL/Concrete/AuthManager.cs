using AdoNet.BLL.Abstract;
using AdoNet.BLL.Helper;
using AdoNet.Entities.Dtos;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using AdoNet.Entities.Entites;
using AdoNet.Entities.Base;
using AdoNet.BLL.Helper.JWT;

namespace AdoNet.BLL.Concrete
{
    public class AuthManager : /*BllBase<User>,*/ IAuthService
    {
        private readonly IUserService _userService;
        private readonly IJWT _jwt;
        public AuthManager(IServiceProvider service, IJWT jwt)
        {
            _userService = service.GetService<IUserService>();
            _jwt = jwt;
        }

        public Response Register(DtoUserForRegister userForRegisterDto)
        {
            try
            {
                bool userCheckEmail = _userService.userCheckEmail(userForRegisterDto.Email);
                if (!userCheckEmail)
                {
                    byte[] passwordHash, passwordSalt;
                    PasswordHashing.CreatePasswordHash(userForRegisterDto.Password, out passwordHash, out passwordSalt);
                    var user = new DtoUserRegister
                    {
                        FirstName = userForRegisterDto.FirstName,
                        LastName = userForRegisterDto.LastName,
                        Email = userForRegisterDto.Email,
                        PasswordSalt = passwordSalt,
                        PasswordHash = passwordHash,
                        Status = true
                    };
                    _userService.Add(ObjectMapper.Mapper.Map<User>(user));
                    return new Response
                    {
                        Data = null,
                        Message = "Success",
                        StatusCode = StatusCodes.Status200OK
                    };
                }

                return new Response
                {
                    Data = null,
                    Message = "Bilgileriniz Hatalidir!",
                    StatusCode = StatusCodes.Status406NotAcceptable
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

        public Response<DtoUserToken> Login(DtoUserLogin login)
        {
            try
            {
                var user = _userService.GetByEmail(login.Email).Data;
                if (user.Email != null)
                {
                    bool isLogin = PasswordHashing.VerifyPaswordHash(login.Password, user.PasswordHash, user.PasswordSalt);
                    if (isLogin)
                    {
                        var token = _jwt.CreateJwtSecurityToken(login.Email);
                        return new Response<DtoUserToken>
                        {
                            Data = new DtoUserToken { Email = login.Email, Token = token },
                            Message = "Success",
                            StatusCode = StatusCodes.Status200OK
                        };
                    }
                }
                return new Response<DtoUserToken>
                {
                    Data = null,
                    Message = $"Kullanıcı Adı veya Şifre Hatalı!",
                    StatusCode = StatusCodes.Status406NotAcceptable
                };
            }
            catch (Exception ex)
            {

                return new Response<DtoUserToken>
                {
                    Data = null,
                    Message = $"Error: {ex.Message}",
                    StatusCode = StatusCodes.Status406NotAcceptable
                };
            }

        }
    }
}
