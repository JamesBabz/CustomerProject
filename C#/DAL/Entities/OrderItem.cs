using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class OrderItem : IEntity
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        public double UnitPrice { get; set; }
    }
}
