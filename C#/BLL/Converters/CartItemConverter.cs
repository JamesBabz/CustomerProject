using BLL.BusinessObjects;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Converters
{
    class CartItemConverter
    {
        private CartConverter cartCon;
        private ProductConverter productCon;

        public CartItemConverter()
        {
            this.cartCon = new CartConverter();
            this.productCon = new ProductConverter();
        }

        public CartItem Convert(CartItemBO cartItem)
        {
            if (cartItem == null) { return null; }
            {
                return new CartItem()
                {
                    Id = cartItem.Id,
                    Cart = cartCon.Convert(cartItem.Cart),
                    CartId = cartItem.CartId,
                    Product = productCon.Convert(cartItem.Product),
                    ProductId = cartItem.ProductId
                };
            }
        }

        public CartItemBO Convert(CartItem cartItem)
        {
            if (cartItem == null) { return null; }
            {
                return new CartItemBO()
                {
                    Id = cartItem.Id,
                    Cart = cartCon.Convert(cartItem.Cart),
                    CartId = cartItem.CartId,
                    Product = productCon.Convert(cartItem.Product),
                    ProductId = cartItem.ProductId
                };
            }
        }
    }
}
