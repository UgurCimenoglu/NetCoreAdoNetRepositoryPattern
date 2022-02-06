using AdoNetDeneme.BLL.Abstract;
using AdoNetDeneme.Entities.Dtos;
using AdoNetDeneme.Entities.Entites;
using AdoNetDeneme.WebApi.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdoNetDeneme.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ApiBaseController<IUserService, User, DtoUser>
    {
        public UserController(IUserService service) : base(service)
        {
        }
    }
}
