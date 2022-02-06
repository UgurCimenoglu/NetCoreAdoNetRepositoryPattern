using AdoNetDeneme.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdoNetDeneme.DAL.Abstract
{
    public interface IGenericRepository<T> where T : IEntity
    {
        T Add(T entity);
        T Update(T entity);
        T Find(int id);
        List<T> GetAll();
        bool Delete(int id);
        bool Delete(T entity);
    }
}
