using System;
using System.Collections.Generic;
using BLL;
using BLL.BusinessObjects;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace RestAPI.Controllers
{
	[EnableCors("MyPolicy")]
	[Produces("application/json")]
	[Route("api/[controller]")]
	public class CustomerController : Controller
	{
        IBLLFacade facade;

        public CustomerController(IBLLFacade facade)
        {
            this.facade = facade;

        }


	    [HttpGet]
	    public IEnumerable<CustomerBO> Get()
	    {
	        return facade.CustomerService.GetAll();
	    }

        [HttpGet("{id}")]
         public CustomerBO Get(int id)
         {
             return facade.CustomerService.Get(id);
         }

        [HttpPost]
	    public IActionResult Post([FromBody]CustomerBO customer)
	    {
	        if (!ModelState.IsValid)
	        {
	            return BadRequest(ModelState);
	        }
	        return Ok(facade.CustomerService.Create(customer));
	    }
    }
}
