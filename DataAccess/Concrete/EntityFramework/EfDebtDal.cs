using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework.Contexts
{
    public class EfDebtDal: EfEntityRepositoryBase<Debt, DebtTrackerContext>,IDebtDal
    {
    }
}
