using AdoNetDeneme.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdoNetDeneme.Entities.Dtos
{
    public class DtoUser:IDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
