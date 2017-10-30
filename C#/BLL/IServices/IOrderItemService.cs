using System;
using System.Collections.Generic;
using System.Text;
using BLL.BusinessObjects;

namespace BLL.IServices
{
    public interface IOrderItemService
    {
        //C
        OrderItemBO Create(OrderItemBO orderItem);
        List<OrderItemBO> AddOrderItems(List<OrderItemBO> orderItems);
        //R
        List<OrderItemBO> GetAll();
        OrderItemBO Get(int id);
        //U
        OrderItemBO Update(OrderItemBO orderItem);
        //D
        OrderItemBO Delete(int id);
    }
}
