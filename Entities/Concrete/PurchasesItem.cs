using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class PurchaseItem:IEntity
    {
        public int Id { get; set; }
        public int PurchaseId { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
    }
}
