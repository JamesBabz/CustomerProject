using System;

namespace DAL
{
    public interface IUnitOfWork : IDisposable
    {
        //ICustomerRepository CustomerRepository { get; }
       
        int Complete();
    }
}
