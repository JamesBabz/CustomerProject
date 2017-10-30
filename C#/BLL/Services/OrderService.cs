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
    public class OrderService : IOrderService
    {

        private IDALFacade facade;
        private OrderConverter orderConv = new OrderConverter();
        private Order newOrder;


        public OrderService(IDALFacade facade)
        {
            this.facade = facade;
        }

        public OrderBO Create(OrderBO order)
        {
            using (var uow = facade.UnitOfWork)
            {
                newOrder = uow.OrderRepository.Create(orderConv.Convert(order));
                uow.Complete();
                return orderConv.Convert(newOrder);
            }
        }

        public OrderBO Delete(int id)
        {
            using (var uow = facade.UnitOfWork)
            {
                newOrder = uow.OrderRepository.Delete(id);
                uow.Complete();
                return orderConv.Convert(newOrder);
            }
        }

        public OrderBO Get(int id)
        {
            using (var uow = facade.UnitOfWork)
            {
                newOrder = uow.OrderRepository.Get(id);
                uow.Complete();
                return orderConv.Convert(newOrder);
            }
        }

        public List<OrderBO> GetAll()
        {
            using (var uow = facade.UnitOfWork)
            {
                return uow.OrderRepository.GetAll().Select(orderConv.Convert).ToList();
            }
        }

        public OrderBO Update(OrderBO order)
        {
            using (var uow = facade.UnitOfWork)
            {
                var orderFromDb = uow.OrderRepository.Get(order.Id);
                if (orderFromDb == null)
                {
                    throw new InvalidOperationException("Order not found");
                }

                orderFromDb.Id = order.Id;
                orderFromDb.OrderDate = order.OrderDate;
                orderFromDb.DeliveryDate = order.DeliveryDate;
                uow.Complete();

                return orderConv.Convert(orderFromDb);

            }
        }
    }
}
