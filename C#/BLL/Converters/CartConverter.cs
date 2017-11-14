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
        readonly CustomerConverter _custConv = new CustomerConverter();

        public Cart Convert(CartBO cart)
        {

            if (cart == null) { return null; }
            {
                return new Cart()
                {
                    Id = cart.Id,
                    Customer = _custConv.Convert(cart.Customer),
                    CustomerId = cart.CustomerId
                    //ProductIds = cart.ProductIds
                };
            }
        }

        public CartBO Convert(Cart cart)
        {
            if (cart == null) { return null; }
            return new CartBO()
            {
                Id = cart.Id,
                Customer = _custConv.Convert(cart.Customer),
                CustomerId = cart.CustomerId
                //ProductIds = cart.ProductIds
            };
        }

    }
}
