using AdoNet.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdoNet.Entities.Dtos
{
    public class DtoUserRegister:IDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public bool Status { get; set; }
    }
}
