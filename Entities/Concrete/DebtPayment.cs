using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class DebtPayment:IEntity
    {
        public int Id { get; set; }
        public int WhoUserId { get; set; }
        public int WhomUserId { get; set; }
        public decimal Amount { get; set; }
        public bool Approved { get; set; }

    }
}
