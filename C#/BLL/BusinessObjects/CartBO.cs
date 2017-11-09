using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.BusinessObjects
{
    public class CartBO : IBusinessObject
    {
        public int Id { get; set; }

        public string ProductIds { get; set; }

        //public List<ProductBO> Products { get; set; }
        

        
    }
}
