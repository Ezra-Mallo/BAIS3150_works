using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BAIS3150ServicesAssignmentWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DecimalController : ControllerBase
    {
        //// GET: api/<DecimalController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<DecimalController>/5
        [HttpGet("{binaryNum}")]
        public string Get(string binaryNum)
        {
            string BinaryNumber = binaryNum;
            int MyDecimal = 0;
            char[] ReverseBinaryNumber = BinaryNumber.ToArray();

            Array.Reverse(ReverseBinaryNumber);
            int newLenght = ReverseBinaryNumber.Length;

            for (int index = 0; index < newLenght; index++)
            {
                if (ReverseBinaryNumber[index] == '1')
                {
                    if (index == 0)
                    {
                        MyDecimal += 1;
                    }
                    else if (index == 1)
                    {
                        MyDecimal += 2;
                    }
                    else if (index >= 2)
                    {
                        int PowerFactor = 1;
                        for (int count = 1; count <= index; count++)
                        {
                            PowerFactor *= 2;
                        }
                        MyDecimal += PowerFactor;
                    }
                }
            }

            return MyDecimal.ToString();
        }

        //// POST api/<DecimalController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<DecimalController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<DecimalController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
