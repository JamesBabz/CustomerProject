using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Cart : IEntity
    {
        public int Id { get; set; }

        public string ProductIds { get; set; }

        //public List<Product> Products { get; set; }
        
    }
}
