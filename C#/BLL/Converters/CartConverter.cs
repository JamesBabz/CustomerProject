using System;
using System.Collections.Generic;
using System.Text;
using BLL.BusinessObjects;
using DAL.Entities;
using System.Linq;

namespace BLL.Converters
{
    public class CartConverter
    {
        private CustomerConverter custCon;
        private ProductConverter prodCon;

        public CartConverter()
        {
            this.custCon = new CustomerConverter();
            this.prodCon = new ProductConverter();
        }

        public Cart Convert(CartBO cart)
        {
            if (cart == null) { return null; }
            {
                return new Cart()
                {
                    Id = cart.Id,
                    ProductIds = cart.ProductIds
                };
            }
        }

        public CartBO Convert(Cart cart)
        {
            if (cart == null) { return null; }
            return new CartBO()
            {
                Id = cart.Id,
                ProductIds = cart.ProductIds
            };
        }

    }
}
