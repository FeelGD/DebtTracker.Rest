using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Concrete
{
    internal class UserGroup:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
