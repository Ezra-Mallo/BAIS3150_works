using BAIS3150ServicesAssignmentWebAPI.TechnicalServices;
using Microsoft.AspNetCore.Mvc;
using BAIS3150ServicesAssignmentWebAPI.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BAIS3150ServicesAssignmentWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        // GET: api/<CustomersController>
        [HttpGet]
        public List<Customer> Get()
        {
            
            Customers CustomerControler = new();
            List<Customer> customers = CustomerControler.GetCustomers();
            return customers;

        }

        // GET api/<CustomersController>/5
        [HttpGet("{CustomerID}")]
        public Customer Get(string CustomerID)
        {
            
            Customers CustomerController = new();
            Customer customer = CustomerController.GetCustomer(CustomerID);
            return customer;
        }

        //// POST api/<CustomersController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<CustomersController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<CustomersController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
