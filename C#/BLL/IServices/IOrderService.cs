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
        List<OrderBO> AddOrders(List<OrderBO> orders);
        //R
        List<OrderBO> GetAll();
        //U
        OrderBO Update(OrderBO order);
        //D
        OrderBO Delete(int id);

    }
}
