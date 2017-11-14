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

        // GET: api/customer
        [HttpGet]
        public IEnumerable<CustomerBO> Get()
        {
            return facade.CustomerService.GetAll();
        }

        // GET: api/customer/5
        [HttpGet("{id}")]
        public CustomerBO Get(int id)
        {
            return facade.CustomerService.Get(id);
        }

        // POST: api/customer/
        [HttpPost]
        public IActionResult Post([FromBody]CustomerBO customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(facade.CustomerService.Create(customer));
        }

        // PUT: api/customer/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]CustomerBO cust)
        {
            if (id != cust.Id)
            {
                return StatusCode(405, "Path id does not match customer ID json object");
            }
            try
            {
                return Ok(facade.CustomerService.Update(cust));
            }
            catch (InvalidOperationException e)
            {
                return StatusCode(404, e.Message);
            }
        }

        // DELETE api/customer/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            try
            {
                return Ok(facade.CustomerService.Delete(id));
            }
            catch (InvalidOperationException e)
            {
                return StatusCode(404, e.Message);
            }
        }
    }
}
