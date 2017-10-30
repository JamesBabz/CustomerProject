using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL.BusinessObjects;
using BLL.Converters;
using BLL.IServices;
using DAL;
using DAL.Entities;

namespace BLL.Services
{
    public class OrderItemService : IOrderItemService
    {
        private IDALFacade facade;
        private OrderItemConverter itemConv = new OrderItemConverter();
        private OrderItem newOrderItem;

        public OrderItemService(IDALFacade facade)
        {
            this.facade = facade;
        }


        public List<OrderItemBO> AddOrderItems(List<OrderItemBO> orderItems)
        {
            throw new NotImplementedException();
        }

        public OrderItemBO Create(OrderItemBO orderItem)
        {
            using (var uow = facade.UnitOfWork)
            {
                newOrderItem = uow.OrderitemRepository.Create(itemConv.Convert(orderItem));
                uow.Complete();
                return itemConv.Convert(newOrderItem);
            }
        }

        public OrderItemBO Delete(int id)
        {
            using (var uow = facade.UnitOfWork)
            {
                newOrderItem = uow.OrderitemRepository.Delete(id);
                uow.Complete();
                return itemConv.Convert(newOrderItem);
            }
        }

        public OrderItemBO Get(int id)
        {
            using (var uow = facade.UnitOfWork)
            {
                newOrderItem = uow.OrderitemRepository.Get(id);
                uow.Complete();
                return itemConv.Convert(newOrderItem);
            }
        }

        public List<OrderItemBO> GetAll()
        {
            using (var uow = facade.UnitOfWork)
            {
                return uow.OrderitemRepository.GetAll().Select(itemConv.Convert).ToList();
            }
        }

        public OrderItemBO Update(OrderItemBO orderItem)
        {
            using (var uow = facade.UnitOfWork)
            {
                var orderItemFromDb = uow.OrderitemRepository.Get(orderItem.Id);
                if (orderItemFromDb == null)
                {
                    throw new InvalidOperationException("OrderItem not found");
                }

                orderItemFromDb.Id = orderItem.Id;
                orderItemFromDb.Quantity = orderItem.Quantity;
                orderItemFromDb.UnitPrice = orderItem.UnitPrice;
                uow.Complete();

                return itemConv.Convert(orderItemFromDb);

            }
        }
    }
}
