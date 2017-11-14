using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.BusinessObjects
{
    public class CartItemBO : IBusinessObject
    {

        public int Id { get; set; }

        public int ProductId { get; set; }

        public ProductBO Product { get; set; }

        public int CartId { get; set; }

        public CartBO Cart { get; set; }

    }
}
