using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.BusinessObjects
{
    public class ProductBO : IBusinessObject
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double ListPrice { get; set; }

    }
}
