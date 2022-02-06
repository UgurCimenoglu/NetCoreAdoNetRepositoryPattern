using AdoNetDeneme.BLL.Abstract;
using AdoNetDeneme.BLL.Helper;
using AdoNetDeneme.DAL.Abstract.UnitOfWorkInterfaces;
using AdoNetDeneme.Entities.Base;
using AdoNetDeneme.Entities.Dtos;
using AdoNetDeneme.Entities.Entites;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdoNetDeneme.BLL.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IResponse<DtoUser> Add(DtoUser item, bool saveChanges)
        {
            try
            {
                using (var context = _unitOfWork.Create())
                {
                    var result = context.Repositories.UserRepository.Add(ObjectMapper.Mapper.Map<User>(item));
                    context.SaveChanges();
                    return new Response<DtoUser>
                    {
                        Data = ObjectMapper.Mapper.Map<DtoUser>(result),
                        StatusCode = StatusCodes.Status200OK,
                        Message = "Success"
                    };
                }
            }
            catch (Exception e)
            {
                return new Response<DtoUser>
                {
                    Data = null,
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error : {e.Message}"
                };
            }

        }

        public IResponse<bool> DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public IResponse<DtoUser> Find(int id)
        {
            throw new NotImplementedException();
        }

        public IResponse<List<DtoUser>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IResponse<DtoUser> Update(DtoUser item)
        {
            throw new NotImplementedException();
        }
    }
}
