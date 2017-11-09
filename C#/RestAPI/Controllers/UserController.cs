using BLL;
using BLL.BusinessObjects;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace RestAPI.Controllers
{
        [EnableCors("MyPolicy")]
        [Produces("application/json")]
        [Route("api/[controller]")]
        public class UserController : Controller
        {
            IBLLFacade facade;

            public UserController(IBLLFacade facade)
            {
                this.facade = facade;
            }

            // GET: api/user
            [HttpGet]
            public IEnumerable<UserBO> Get()
            {
                return facade.UserService.GetAll();
            }

        // GET: api/user/5
        [HttpGet("{id}")]
            public UserBO Get(int id)
            {
                return facade.UserService.Get(id);
            }

        // POST: api/user/
        [HttpPost]
            public IActionResult Post([FromBody]UserBO user)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                return Ok(facade.UserService.Create(user));
            }

        // PUT: api/user/5
        [HttpPut("{id}")]
            public IActionResult Put(int id, [FromBody]UserBO user)
            {
                if (id != user.Id)
                {
                    return StatusCode(405, "Path id does not match user ID json object");
                }
                try
                {
                    return Ok(facade.UserService.Update(user));
                }
                catch (InvalidOperationException e)
                {
                    return StatusCode(404, e.Message);
                }

            }

        // DELETE api/user/5
        [HttpDelete("{id}")]
            public void Delete(int id)
            {
                facade.UserService.Delete(id);

            }
        }
    }
