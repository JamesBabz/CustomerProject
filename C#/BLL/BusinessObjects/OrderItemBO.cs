using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.BusinessObjects
{
    public class OrderItemBO : IBusinessObject
    {
        public int Id { get; internal set; }

        public int Quantity { get; set; }

        public double UnitPrice { get; set; }

        
    }
}
