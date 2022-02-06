using AdoNetDeneme.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdoNetDeneme.Entities.Entites
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
