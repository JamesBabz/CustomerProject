﻿using BLL.BusinessObjects;
using BLL.Converters;
using BLL.IServices;
using DAL;
using DAL.Entities;
using DAL.Facade;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{

    public class CustomerService : ICustomerService
    {
        private IDALFacade facade;
        private CustomerConverter custConv = new CustomerConverter();
        private Customer newCustomer;
        
        public CustomerService(IDALFacade facade)
        {
            this.facade = facade;
        }

        public CustomerBO Create(CustomerBO cust)
        {
            using (var uow = facade.UnitOfWork)
            {
                newCustomer = uow.CustomerRepository.Create(custConv.Convert(cust));
                uow.Complete();
                return custConv.Convert(newCustomer);
            }
        }

        public CustomerBO Delete(int id)
        {
            using (var uow = facade.UnitOfWork)
            {
                newCustomer = uow.CustomerRepository.Delete(id);
                uow.Complete();
                return custConv.Convert(newCustomer);
            }
        }

        public CustomerBO Get(int id)
        {
            using (var uow = facade.UnitOfWork)
            {
                newCustomer = uow.CustomerRepository.Get(id);
               // newCustomer.Cart = uow.CartItemRepository.Get(newCustomer.CartId);
                uow.Complete();
                return custConv.Convert(newCustomer);
            }
        }

        public List<CustomerBO> GetAll()
        {
            using (var uow = facade.UnitOfWork)
            {
                return uow.CustomerRepository.GetAll().Select(custConv.Convert).ToList();
            }
        }

        public CustomerBO Update(CustomerBO cust)
        {
            using (var uow = facade.UnitOfWork)
            {
                var customerFromDb = uow.CustomerRepository.Get(cust.Id);
                if (customerFromDb == null)
                {
                    throw new InvalidOperationException("Customer not found");
                }

                customerFromDb.Id = cust.Id;
                customerFromDb.FirstName = cust.FirstName;
                customerFromDb.LastName = cust.LastName;
                customerFromDb.Address = cust.Address;
                uow.Complete();

                return custConv.Convert(customerFromDb);
            }
        }
    }
}
