using AdoNetDeneme.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdoNetDeneme.BLL.Abstract
{
    public interface IBllBase<T, TDto> where T : IEntity where TDto : IDto
    {
        IResponse<TDto> Add(TDto item, bool saveChanges=true);
        IResponse<TDto> Update(TDto item);
        IResponse<TDto> Find(int id);
        IResponse<List<TDto>> GetAll();
        IResponse<bool> DeleteById(int id);

    }
}
