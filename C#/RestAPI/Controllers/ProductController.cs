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
    public class ProductController : Controller
    {
        IBLLFacade facade;

        public ProductController(IBLLFacade facade)
        {
            this.facade = facade;
        }

        // GET: api/product
        [HttpGet]
        public IEnumerable<ProductBO> Get()
        {
            return facade.ProductService.GetAll();
        }

        // GET: api/order/5
        [HttpGet("{id}")]
        public ProductBO Get(int id)
        {
            return facade.ProductService.Get(id);
        }

        // POST: api/order/
        [HttpPost]
        public IActionResult Post([FromBody]ProductBO product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(facade.ProductService.Create(product));
        }

        // PUT: api/order/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]ProductBO product)
        {
            if (id != product.Id)
            {
                return StatusCode(405, "Path id does not match product ID json object");
            }
            try
            {
                return Ok(facade.ProductService.Update(product));
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
            facade.ProductService.Delete(id);

        }
    }
}