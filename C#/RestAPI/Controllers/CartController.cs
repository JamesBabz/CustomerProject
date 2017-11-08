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
    public class CartController : Controller
    {
        IBLLFacade facade;

        public CartController(IBLLFacade facade)
        {
            this.facade = facade;
        }

        // GET: api/cart
        [HttpGet]
        public IEnumerable<CartBO> Get()
        {
            return facade.CartService.GetAll();
        }

        // GET: api/order/5
        [HttpGet("{id}")]
        public CartBO Get(int id)
        {
            return facade.CartService.Get(id);
        }

        // POST: api/cart/
        [HttpPost]
        public IActionResult Post([FromBody]CartBO cart)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(facade.CartService.Create(cart));
        }

        // PUT: api/cart/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]CartBO cart)
        {
            if (id != cart.Id)
            {
                return StatusCode(405, "Path id does not match cart ID json object");
            }
            try
            {
                return Ok(facade.CartService.Update(cart));
            }
            catch (InvalidOperationException e)
            {
                return StatusCode(404, e.Message);
            }

        }

        // DELETE api/cart/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                return Ok(facade.CartService.Delete(id));
            }
            catch (InvalidOperationException e)
            {
                return StatusCode(404, e.Message);
            }

        }
    }
}