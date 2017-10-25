using System;
using System.Collections.Generic;
using System.Text;
using BLL.BusinessObjects;
using DAL.Entities;

namespace BLL.Converters
{
    public class OrderItemConverter
    {
        public OrderItem Convert(OrderItemBO orderItem)
        {
            if (orderItem == null) { return null; }
            {
                return new OrderItem()
                {
                    Id = orderItem.Id,
                    Quantity = orderItem.Quantity,
                    UnitPrice = orderItem.UnitPrice
                };
            }
        }

        public OrderItemBO Convert(OrderItem orderItem)
        {
            if (orderItem == null) { return null; }
            return new OrderItemBO()
            {
                Id = orderItem.Id,
                Quantity = orderItem.Quantity,
                UnitPrice = orderItem.UnitPrice
            };
        }

    }
}
