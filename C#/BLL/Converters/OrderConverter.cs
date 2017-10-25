using System;
using System.Collections.Generic;
using System.Text;
using BLL.BusinessObjects;
using DAL.Entities;

namespace BLL.Converters
{
    public class OrderConverter
    {
        public Order Convert(OrderBO order)
        {
            if (order == null) { return null; }
            {
                return new Order()
                {
                    Id = order.Id,
                    DeliveryDate = order.DeliveryDate,
                    OrderDate = order.OrderDate
                };
            }
        }

        public OrderBO Convert(Order order)
        {
            if (order == null) { return null; }
            return new OrderBO()
            {
                Id = order.Id,
                OrderDate = order.OrderDate,
                DeliveryDate = order.DeliveryDate
            };
        }



    }
}
