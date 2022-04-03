using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Purchase : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TypeId { get; set; }
        public decimal Amount { get; set; }
        public string Location { get; set; }
        public byte[] Receipt { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public bool Approved { get; set; }

    }
}
