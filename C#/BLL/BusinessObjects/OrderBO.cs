using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.BusinessObjects
{
    public class OrderBO : IBusinessObject
    {
        public int Id { get; internal set; }

        public DateTime OrderDate { get; set; }

        public DateTime DeliveryDate { get; set; }

    }
}
