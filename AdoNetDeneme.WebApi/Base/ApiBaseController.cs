using AdoNetDeneme.BLL.Abstract;
using AdoNetDeneme.Entities.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdoNetDeneme.WebApi.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiBaseController<TInterface, T, TDto> : ControllerBase where TInterface: IBllBase<T,TDto> where T: IEntity where TDto :IDto
    {
        protected TInterface service;

        public ApiBaseController(TInterface service)
        {
            this.service = service;
        }

        [HttpPost("Add")]
        public IResponse<TDto> Add(TDto entity)
        {
            try
            {
                return service.Add(entity);

            }
            catch (Exception ex)
            {
                return new Response<TDto>
                {
                    Message = $"Error:{ex.Message}",
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Data = default
                };
            }
        }
    }
}
