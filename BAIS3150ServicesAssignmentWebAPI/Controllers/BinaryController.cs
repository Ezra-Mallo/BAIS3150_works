using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BAIS3150ServicesAssignmentWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BinaryController : ControllerBase
    {
        // GET: api/<BinaryController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<BinaryController>/5
        [HttpGet("{decimalNum}")]
        public string Get(int decimalNum)
        {
            string binaryNum = string.Empty;
            char[] reverseBinaryNum;
            int remainder = 0; // mod
            int number = decimalNum;

            while (number != 0)
            {
                remainder = number % 2;
                binaryNum = binaryNum + remainder;
                number = number / 2;
            }

            reverseBinaryNum = binaryNum.ToArray();
            Array.Reverse(reverseBinaryNum);

            return new string(reverseBinaryNum);
        }

        //// POST api/<BinaryController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<BinaryController>/5
        //[HttpPut("{decimalNum}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<BinaryController>/5
        //[HttpDelete("{decimalNum}")]
        //public void Delete(int id)
        //{
        //}
    }
}
