using System;
using System.Collections.Generic;
using System.Text;

namespace AdoNetDeneme.DAL.Abstract.UnitOfWorkInterfaces
{
    public interface IUnitOfWorkAdapter:IDisposable
    {
        IUnitOfWorkRepository Repositories { get; }
        void SaveChanges();
        void RollBack();
    }
}
