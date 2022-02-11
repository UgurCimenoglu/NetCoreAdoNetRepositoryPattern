
using AdoNet.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdoNet.Entities.Dtos
{
    public class DtoUserToken : IDto
    {
        public string Email { get; set; }
        public object Token { get; set; }
    }
}
