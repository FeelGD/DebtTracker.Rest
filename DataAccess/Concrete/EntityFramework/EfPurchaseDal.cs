using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfPurchaseDal: EfEntityRepositoryBase<EfPurchaseDal,DebtTrackerContext>,IPurchaseDal
    {
    }
}
