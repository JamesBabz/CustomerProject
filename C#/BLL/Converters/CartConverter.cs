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
                    Quantity = cart.Quantity,
                    UnitPrice = cart.UnitPrice
                };
            }
        }

        public CartBO Convert(Cart cart)
        {
            if (cart == null) { return null; }
            return new CartBO()
            {
                Id = cart.Id,
                Quantity = cart.Quantity,
                UnitPrice = cart.UnitPrice
            };
        }

    }
}
