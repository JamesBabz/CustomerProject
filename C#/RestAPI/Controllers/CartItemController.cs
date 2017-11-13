using BLL;
using BLL.BusinessObjects;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPI.Controllers
{
    [EnableCors("MyPolicy")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class CartItemController : Controller
    {
        IBLLFacade facade;

        public CartItemController(IBLLFacade facade)
        {
            this.facade = facade;
        }

        // GET: api/cartItem
        [HttpGet]
        public IEnumerable<CartItemBO> Get()
        {
            return facade.CartItemService.GetAll();
        }

        // GET: api/cartItem/5
        [HttpGet("{id}")]
        public CartItemBO Get(int id)
        {
            return facade.CartItemService.Get(id);
        }

        // POST: api/cartItem/
        //[HttpPost]
        //public IActionResult Post([FromBody]CartBO cart, ProductBO prod)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    return Ok(facade.CartItemService.Create(cart, prod));
        //}

        // POST: api/cartItem/
        [HttpPost]
        public IActionResult Post([FromBody] ProductBO prod)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var cartItem = facade.CartItemService.Create(prod);
            Console.WriteLine(cartItem);

            return Ok(cartItem);
        }

        // PUT: api/cartItem/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]CartItemBO cartItem)
        {
            if (id != cartItem.Id)
            {
                return StatusCode(405, "Path id does not match cart ID json object");
            }
            try
            {
                return Ok(facade.CartItemService.Update(cartItem));
            }
            catch (InvalidOperationException e)
            {
                return StatusCode(404, e.Message);
            }

        }

        // DELETE api/cartItem/5
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
