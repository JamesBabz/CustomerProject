using System;
using System.Collections.Generic;
using System.Text;
using BLL.BusinessObjects;

namespace BLL.IServices
{
    public interface IOrderService
    {
        //C
        OrderBO Create(OrderBO order);
        //R
        List<OrderBO> GetAll();
        OrderBO Get(int id);
        //U
        OrderBO Update(OrderBO order);
        //D
        OrderBO Delete(int id);

    }
}
