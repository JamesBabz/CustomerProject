using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Cart : IEntity
    {
        public int Id { get; set; }

        //public List<int> ProductIds { get; set; }

        //public List<Product> Products { get; set; }

        public Customer Customer { get; set; }

        public int CustomerId { get; set; }
    }
}
