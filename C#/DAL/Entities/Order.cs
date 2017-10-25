using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Order : IEntity
    {

        public int Id { get; internal set; }

        public DateTime OrderDate { get; set; }

        public DateTime DeliveryDate { get; set; }

    }
}
