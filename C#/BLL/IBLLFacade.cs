using BLL.BusinessObjects;
using BLL.IServices;
using BLL.Services;

namespace BLL
{
    public interface IBLLFacade
    {
        CustomerService CustomerService { get; }
        OrderItemService OrderItemService { get; }
        OrderService OrderService { get; }
        ProductService ProductService { get; }
    }
}
