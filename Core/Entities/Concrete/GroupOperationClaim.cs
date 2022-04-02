using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Core.Entities.Concrete
{
    public class GroupOperationClaim:IEntity
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public int OperationClaimId { get; set; }

    }
}
