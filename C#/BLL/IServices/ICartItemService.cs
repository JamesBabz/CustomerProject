using BLL.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.IServices
{
    interface ICartItemService
    {
        //C
        CartItemBO Create(CartItemBO cartItem);
        List<CartItemBO> AddCartItems(List<CartItemBO> cartItems);
        //R
        List<CartItemBO> GetAll();
        CartItemBO Get(int id);
        //U
        CartItemBO Update(CartItemBO cartItem);
        //D
        CartItemBO Delete(int id);
    }
}
