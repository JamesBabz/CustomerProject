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
        //R
        List<CustomerBO> GetAll();
        CustomerBO Get(int id);
        //U
        CustomerBO Update(CustomerBO cust);
        //D
        CustomerBO Delete(int id);
    }
}
