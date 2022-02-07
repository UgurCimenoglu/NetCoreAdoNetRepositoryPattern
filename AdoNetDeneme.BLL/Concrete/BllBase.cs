using AdoNet.DAL.Abstract.UnitOfWorkInterfaces;
using AdoNetDeneme.BLL.Abstract;
using AdoNetDeneme.BLL.Helper;
using AdoNetDeneme.DAL.Abstract;
using AdoNetDeneme.Entities.Base;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace AdoNet.BLL.Concrete
{
    public class BllBase<T, TDto> : IBllBase<T, TDto> where T : IEntity where TDto : IDto
    {
        private readonly IServiceProvider _service;
        private readonly IUnitOfWorks _unitOfWorks;
        protected readonly IGenericRepository<T> _genericRepository;

        public BllBase(IServiceProvider service)
        {
            _unitOfWorks = service.GetService<IUnitOfWorks>();
            _genericRepository = _unitOfWorks.GetGenericRepository<T>();
            _service = service;
        }

        public IResponse<TDto> Add(TDto item, bool saveChanges = true)
        {
            try
            {
                var entity = ObjectMapper.Mapper.Map<T>(item);
                _genericRepository.Add(entity, "addUser");
                if (saveChanges)
                    Save();
                return new Response<TDto>
                {
                    Data = default,
                    Message = "Success",
                    StatusCode = StatusCodes.Status200OK
                };
            }
            catch (Exception ex)
            {
                return new Response<TDto>
                {
                    Data = default,
                    Message = $"Error {ex.Message}",
                    StatusCode = StatusCodes.Status500InternalServerError
                };
            }

        }

        public IResponse<bool> DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public IResponse<TDto> Find(int id)
        {
            throw new NotImplementedException();
        }

        public IResponse<List<TDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IResponse<TDto> Update(TDto item)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            _unitOfWorks.SaveChanges();
        }
    }
}
