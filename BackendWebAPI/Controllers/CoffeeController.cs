using BackendWebAPI.DAL;
using Microsoft.AspNetCore.Mvc;
using MyXamarinApps.Shared;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackendWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoffeeController : ControllerBase
    {
        private ICoffee _coffee;
        public CoffeeController(ICoffee coffee)
        {
            _coffee = coffee;
        }

        // GET: api/<CoffeeController>
        [HttpGet]
        public IEnumerable<Coffee> Get()
        {
            var results = _coffee.GetAll();
            return results;
        }

        // GET api/<CoffeeController>/5
        [HttpGet("{id}")]
        public Coffee Get(int id)
        {
            var result = _coffee.GetById(id);
            return result;
        }

        // POST api/<CoffeeController>
        [HttpPost]
        public ActionResult Post([FromBody] Coffee coffee)
        {
            try
            {
                _coffee.Insert(coffee);
                return Ok($"Berhasil menambahkan data coffee {coffee.Name}");
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<CoffeeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CoffeeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
