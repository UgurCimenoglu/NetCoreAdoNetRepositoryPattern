using AdoNet.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdoNet.DAL.Abstract.UnitOfWorkInterfaces
{
    public interface IUnitOfWorks : IDisposable
    {
        //IGenericRepository<T> GetGenericRepository<T>() where T : IEntity;
        bool BeginTransaction();
        bool RollBackTransaction();
        void SaveChanges();
    }
}
