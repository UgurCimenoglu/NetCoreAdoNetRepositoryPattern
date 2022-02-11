using AdoNet.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdoNet.DAL.Abstract
{
    public interface IGenericRepository<T> where T : IEntity
    {
        T Add(T entity, string Procedure=default);
        T Update(T entity, string Procedure = default);
        T Find(int id, string Procedure = default);
        List<T> GetAll(string Procedure = default);
        bool Delete(int id, string Procedure = default);
        bool Delete(T entity, string Procedure = default);
    }
}
