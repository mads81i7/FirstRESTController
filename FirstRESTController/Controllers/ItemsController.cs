using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstRESTController.Managers;
using FirstRESTController.Models;
using Microsoft.AspNetCore.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FirstRESTController.Controllers
{
    [Route("yourFavoriteName")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IItemsManager Manager;

        public ItemsController(ItemContext context)
        {
            Manager = new ItemsManagerDB(context);
        }

        // GET: api/<ItemsController>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public ActionResult<IEnumerable<Item>> Get([FromQuery] string substring)
        {
            List<Item> items = Manager.GetAll(substring);
            return Ok(items);
        }

        // GET api/<ItemsController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public ActionResult<Item> Get(int id)
        {
            Item item = Manager.GetById(id);
            if (item == null)
            {
                return NotFound("There is no item with ID: " + id);
            }

            return Ok(item);
        }

        // POST api/<ItemsController>
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost]
        public ActionResult<Item> Post([FromBody] Item value)
        {
            if (value == null)
            {
                return NotFound("The item that you were trying to add could not be found");
            }

            if (Manager.GetAll("").FindAll(item=> item.Id == value.Id).Count > 0)
            {
                return Conflict("The item that you were trying to add already exists");
            }
            return Manager.Add(value);
        }

        // PUT api/<ItemsController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Item value)
        {
            Item item = Manager.GetById(id);
            if (item == null)           
            {
                return NotFound("The item that you were trying to update to, could not be found");
            }
            if (String.IsNullOrEmpty(value.Name))
            {
                return NoContent();
            }
            Manager.Update(id, value);
            return Ok();
        }

        // DELETE api/<ItemsController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Item item = Manager.GetById(id);
            if (item == null)
            {
                return NotFound("There is no item with ID: " + id);
            }
            Manager.Delete(id);
            return Ok();
            
        }
    }
}
