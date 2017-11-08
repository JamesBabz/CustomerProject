using System;
using System.Collections.Generic;
using System.Text;
using BLL.BusinessObjects;
using DAL.Entities;

namespace BLL.Converters
{
    public class CartConverter
    {
        public Cart Convert(CartBO cart)
        {
            if (cart == null) { return null; }
            {
                return new Cart()
                {
                    Id = cart.Id,
                    ProductIds = cart.ProductIds,
                    Customer = new CustomerConverter().Convert(cart.Customer),
                    CustomerId = cart.CustomerId
                };
            }
        }

        public CartBO Convert(Cart cart)
        {
            if (cart == null) { return null; }
            return new CartBO()
            {
                Id = cart.Id,
                ProductIds = cart.ProductIds,
                Customer = new CustomerConverter().Convert(cart.Customer),
                CustomerId = cart.CustomerId
            };
        }

    }
}
