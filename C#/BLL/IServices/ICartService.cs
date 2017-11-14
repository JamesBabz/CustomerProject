using System;
using System.Collections.Generic;
using System.Text;
using BLL.BusinessObjects;

namespace BLL.IServices
{
    public interface ICartService
    {
        //C
        CartBO Create(CartBO cart);
        List<CartBO> AddCarts(List<CartBO> carts);
        //R
        List<CartBO> GetAll();
        CartBO Get(int id);
        //U
        CartBO Update(CartBO cart);
        //D
        CartBO Delete(int id);
    }
}
