using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
//using Entities.Concrete;
/*using Remotion.Linq.Parsing.Structure.IntermediateModel;*/

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal:EfEntityRepositoryBase<User,DebtTrackerContext>,IUserDal
    {
        public  List<OperationClaim> GetClaims(User user)
        {
           
            using (var context = new DebtTrackerContext())
            {

                var result = from operationClaim in context.OperationClaims
                    join GroupOperationClaim in context.GroupOperationClaims
                        on operationClaim.Id equals GroupOperationClaim.OperationClaimId
                    where GroupOperationClaim.GroupId == user.GroupId
                    select new OperationClaim {Id = operationClaim.Id, Name = operationClaim.Name};
                return  result.ToList();

            }
        }
    }
}
