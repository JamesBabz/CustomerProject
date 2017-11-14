using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class CartItem : IEntity
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

        public int CartId { get; set; }

        public Cart Cart { get; set; }
    }
}
