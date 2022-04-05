using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IDebtService
    {
        IResult Add(Debt debt);
        IResult Delete(int id);
        IResult Update(Debt debt);
        IDataResult<Debt> Get(int id);
        IDataResult<List<Debt>> GetList(int ownerId);
    }
}
