using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.Concrete
{
    public class Customers : IEntity
    {
        public int UsersId { get; set; }
        public string CompanyName { get; set; }
        public int CustomersId { get; set; }
    }
}
