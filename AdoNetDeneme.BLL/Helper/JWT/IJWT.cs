using System;
using System.Collections.Generic;
using System.Text;

namespace AdoNet.BLL.Helper.JWT
{
    public interface IJWT
    {
        public string CreateJwtSecurityToken(string email);
    }
}
