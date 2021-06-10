using Microsoft.AspNetCore.Mvc;
using CustomersRESTAPI.Interfaces;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CustomersRESTAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private ICustomersService _customersService;
        public CustomersController(ICustomersService customersService)
        {
            _customersService = customersService;
        }

        // GET: api/<CustomerController>
        [HttpGet]
        public string Get()
        {
            return JsonSerializer.Serialize(_customersService.Get());
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            //Return a customer with the specified ID

            return JsonSerializer.Serialize(_customersService.Get(id));
        }

        // POST api/<CustomerController>
        [HttpPost]
        public string Post([FromBody] Customer customer)
        {
            //Add a new customer record here

            return JsonSerializer.Serialize(_customersService.Post(customer));
        }

        // PUT api/<CustomerController>/5
        [HttpPut]
        public string Put([FromBody] Customer customer)
        {
            //Update a customer record here

            return JsonSerializer.Serialize(_customersService.Put(customer));
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            //Delete the Customer with this ID
            return JsonSerializer.Serialize(_customersService.Delete(id));
        }
    }
}
