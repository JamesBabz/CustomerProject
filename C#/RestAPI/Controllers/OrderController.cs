using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using BLL.BusinessObjects;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace RestAPI.Controllers
{
    [EnableCors("MyPolicy")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        IBLLFacade facade;

        public OrderController(IBLLFacade facade)
        {
            this.facade = facade;
        }

        // GET: api/order
        [HttpGet]
        public IEnumerable<OrderBO> Get()
        {
            return facade.OrderService.GetAll();
        }

        // GET: api/order/5
        [HttpGet("{id}")]
        public OrderBO Get(int id)
        {
            return facade.OrderService.Get(id);
        }

        // POST: api/order/
        [HttpPost]
        public IActionResult Post([FromBody]OrderBO order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(facade.OrderService.Create(order));
        }

        // PUT: api/order/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]OrderBO order)
        {
            if (id != order.Id)
            {
                return StatusCode(405, "Path id does not match order ID json object");
            }
            try
            {
                return Ok(facade.OrderService.Update(order));
            }
            catch (InvalidOperationException e)
            {
                return StatusCode(404, e.Message);
            }
        }

        // DELETE api/order/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            facade.OrderService.Delete(id);
        }
    }
}