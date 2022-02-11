using AdoNet.DAL.Abstract.UnitOfWorkInterfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using AdoNet.BLL.Abstract;
using AdoNet.Entities.Base;
using AdoNet.DAL.Abstract;

namespace AdoNet.BLL.Concrete
{
    //public abstract class BllBase<T,TDto> :IBllBase<T,TDto> where T : IEntity where TDto : IDto 
    public abstract class BllBase<T> :IBllBase<T> where T : IEntity 
    {
        private readonly IServiceProvider _service;
        private readonly IUnitOfWorks _unitOfWorks;
        //protected readonly IGenericRepository<T> _genericRepository;

        public BllBase(IServiceProvider service)
        {
            _unitOfWorks = service.GetService<IUnitOfWorks>();
           //_genericRepository = _unitOfWorks.GetGenericRepository<T>();
            _service = service;
            
        }
    }
}
