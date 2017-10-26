using BLL.BusinessObjects;
using BLL.IServices;
using BLL.Services;

namespace BLL
{
    public interface IBLLFacade
    {
        CustomerService CustomerService { get; }
    }
}
