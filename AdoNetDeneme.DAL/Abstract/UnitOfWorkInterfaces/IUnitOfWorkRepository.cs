using System;
using System.Collections.Generic;
using System.Text;

namespace AdoNetDeneme.DAL.Abstract.UnitOfWorkInterfaces
{
    public interface IUnitOfWorkRepository
    {
        IUserRepository UserRepository { get; }
    }
}
