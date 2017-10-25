using System;
using System.Collections.Generic;
using System.Text;
using BLL.BusinessObjects;

namespace BLL.IServices
{
    public interface ICustomerService
    {
        //C
        CustomerBO Create(CustomerBO cust);
        List<CustomerBO> AddCustomers(List<CustomerBO>customers);
        //R
        List<CustomerBO> GetAll();
        //U
        CustomerBO Update(CustomerBO cust);
        //D
        CustomerBO Delete(int id);
    }
}
