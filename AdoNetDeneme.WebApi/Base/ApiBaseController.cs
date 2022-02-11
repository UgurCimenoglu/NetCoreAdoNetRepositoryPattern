using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdoNet.WebApi.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiBaseController:ControllerBase
    {
        //protected TInterface service;

        //public ApiBaseController(TInterface service)
        //{
        //    this.service = service;
        //}

        //[HttpPost("Add")]
        //public IResponse Add(TDto entity)
        //{
        //    try
        //    {
        //        return service.Add(entity);

        //    }
        //    catch (Exception ex)
        //    {
        //        return new Response
        //        {
        //            Message = $"Error:{ex.Message}",
        //            StatusCode = StatusCodes.Status500InternalServerError,
        //            Data = default
        //        };
        //    }
        //}
    }
}
