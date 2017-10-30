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
    public class OrderItemController : Controller
    {
        IBLLFacade facade;

        public OrderItemController(IBLLFacade facade)
        {
            this.facade = facade;
        }

        // GET: api/orderItem
        [HttpGet]
        public IEnumerable<OrderItemBO> Get()
        {
            return facade.OrderItemService.GetAll();
        }

        // GET: api/order/5
        [HttpGet("{id}")]
        public OrderItemBO Get(int id)
        {
            return facade.OrderItemService.Get(id);
        }

        // POST: api/orderItem/
        [HttpPost]
        public IActionResult Post([FromBody]OrderItemBO orderItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(facade.OrderItemService.Create(orderItem));
        }

        // PUT: api/orderItem/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]OrderItemBO orderItem)
        {
            if (id != orderItem.Id)
            {
                return StatusCode(405, "Path id does not match orderItem ID json object");
            }
            try
            {
                return Ok(facade.OrderItemService.Update(orderItem));
            }
            catch (InvalidOperationException e)
            {
                return StatusCode(404, e.Message);
            }

        }

        // DELETE api/orderItem/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            facade.OrderItemService.Delete(id);

        }
    }
}