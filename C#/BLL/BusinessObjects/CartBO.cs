using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.BusinessObjects
{
    public class CartBO : IBusinessObject
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        public double UnitPrice { get; set; }

        
    }
}
