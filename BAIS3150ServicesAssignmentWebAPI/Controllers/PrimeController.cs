using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BAIS3150ServicesAssignmentWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrimeController : ControllerBase
    {
        //// GET: api/<PrimeController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<PrimeController>/5
        [HttpGet("{number}")]
        public string Get(long number)
        {
            string ReturnValues = "Enter an interger(0 to 2,147,483,647)";
            if (number > 0 && number <= 2147483647)
            {
                
                if (number > 7 && (number % 2 == 0 || number % 3 == 0 || number % 5 == 0 || number % 7 == 0))
                {
                    ReturnValues = "False";
                }
                else if (number > 5 && (number % 2 == 0 || number % 3 == 0 || number % 5 == 0))
                {
                    ReturnValues = "False";
                }
                else if (number > 3 && (number % 2 == 0 || number % 3 == 0))
                {
                    ReturnValues = "False";
                }
                else if (number == 2 || number == 1)
                {
                    ReturnValues = "True";
                }

            }

            return ReturnValues;
        }

        //// POST api/<PrimeController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<PrimeController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<PrimeController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
