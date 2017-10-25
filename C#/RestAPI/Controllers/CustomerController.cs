using BLL;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace RestAPI.Controllers
{
	[EnableCors("MyPolicy")]
	[Produces("application/json")]
	[Route("api/addresses")]
	public class CustomerController : Controller
	{
        IBLLFacade facade;

        public CustomerController(IBLLFacade facade)
        {
            this.facade = facade;
        }
    }
}
