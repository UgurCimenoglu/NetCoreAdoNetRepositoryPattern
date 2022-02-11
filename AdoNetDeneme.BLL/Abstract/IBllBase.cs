using AdoNet.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdoNet.BLL.Abstract
{
    //public interface IBllBase<T, TDto> where T : IEntity where TDto : IDto
    public interface IBllBase<T> where T : IEntity 
    {
        //IResponse Add(TDto item, bool saveChanges=true);
        //IResponse Update(TDto item);
        //IResponse<TDto> Find(int id);
        //IResponse<List<TDto>> GetAll();
        //IResponse<bool> DeleteById(int id);
        //void Save();
    }
}
