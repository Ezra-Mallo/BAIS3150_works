using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text.Json;
using BAIS3150ConsoleAppWebAPIClient.Domain;


namespace BAIS3150ConsoleAppWebAPIClient
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            using (HttpClient WebAPIClient = new())
            {
                MediaTypeWithQualityHeaderValue ContentType = new("application/json");
                WebAPIClient.DefaultRequestHeaders.Accept.Add(ContentType);
                WebAPIClient.BaseAddress = new Uri("https://localhost:44385");       //check your local  address

                HttpResponseMessage WebAPIResponseMessage;   
                string WebAPIGetContent = string.Empty;
                string SerializedJson = string.Empty;
                StringContent WebAPIPostPutContent;
                JsonSerializerOptions Options = new()
                {
                    PropertyNameCaseInsensitive = true //default = false
                };






                // GET: api/<ItemsController>
                //[HttpGet]
                //public List<Item> Get() //method
                Console.WriteLine("-----------");
                Console.WriteLine("HttpGet");
                Console.WriteLine("------------");

                WebAPIResponseMessage = await WebAPIClient.GetAsync("/api/Items");

                WebAPIGetContent = await WebAPIResponseMessage.Content.ReadAsStringAsync();

                List<Item> ExampleItemsObjectCollection = JsonSerializer.Deserialize<List<Item>>(WebAPIGetContent, Options)!; //the ! help to ignore the error flag

                foreach (Item ExampleItemObject in ExampleItemsObjectCollection)
                {
                    Console.WriteLine("-");
                    Console.WriteLine(ExampleItemObject.ItemNumber);
                    Console.WriteLine(ExampleItemObject.Description);
                    Console.WriteLine(ExampleItemObject.UnitPrice);
                }







                // GET api/<ItemsController>/5
                //[HttpGet("{itemNumber}")]
                //public Item Get(int itemNumber) //method
                Console.WriteLine("----------------------------------");
                Console.WriteLine("HttpGet {itemNumber}");
                Console.WriteLine("----------------------------------");

                WebAPIResponseMessage = await WebAPIClient.GetAsync("/api/Items/2"); // you can modify thsi hardcodded 2 to make it dynamic.

                WebAPIGetContent = await WebAPIResponseMessage.Content.ReadAsStringAsync();

                Item ExampleItem = JsonSerializer.Deserialize<Item>(WebAPIGetContent, Options)!;

                Console.WriteLine("-");
                Console.WriteLine(ExampleItem.ItemNumber);
                Console.WriteLine(ExampleItem.Description);
                Console.WriteLine(ExampleItem.UnitPrice);







                // POST api/<ItemsController>
                //[HttpPost]
                //public void Post([FromBody] Item exampleItem)   //method
                Console.WriteLine("------------");
                Console.WriteLine("HttpPost");
                Console.WriteLine("------------");


                ExampleItem.ItemNumber = 5; // note needed for IDENTITY column 
                ExampleItem.Description = "HttpPost Insert Description";
                ExampleItem.UnitPrice = (decimal)1.11; // casted intor a decimal


                SerializedJson = JsonSerializer.Serialize(ExampleItem);

                WebAPIPostPutContent = new StringContent(SerializedJson, System.Text.Encoding.UTF8, "application/json");

                WebAPIResponseMessage = await WebAPIClient.PostAsync("/api/Items", WebAPIPostPutContent);

                if (WebAPIResponseMessage.IsSuccessStatusCode)
                {
                    Console.WriteLine(WebAPIResponseMessage.StatusCode + " - Insert successful");
                }
                else
                {
                    Console.WriteLine(WebAPIResponseMessage.StatusCode + " - Insert not successful");
                }









                // PUT api/<ItemsController>/5
                //[HttpPut("{itemNumber}")]
                //public void Put(int itemNumber, [FromBody] Item exampleItem)      //method
                Console.WriteLine("-----------------------------");
                Console.WriteLine("HttpPut {itemNumber}");
                Console.WriteLine("-----------------------------");


                ExampleItem.ItemNumber = 4; // note needed for IDENTITY column 
                ExampleItem.Description = "HttpPost update Description";
                ExampleItem.UnitPrice = (decimal)14.11; // casted intor a decimal

                SerializedJson = JsonSerializer.Serialize(ExampleItem);
                WebAPIPostPutContent = new StringContent(SerializedJson, System.Text.Encoding.UTF8, "application/json");

                WebAPIResponseMessage = await WebAPIClient.PutAsync("/api/Items/4", WebAPIPostPutContent);

                if (WebAPIResponseMessage.IsSuccessStatusCode)
                {
                    Console.WriteLine(WebAPIResponseMessage.StatusCode + " - Update successful");
                }
                else
                {
                    Console.WriteLine(WebAPIResponseMessage.StatusCode + " - Update not successful");
                }









                // DELETE api/<ItemsController>/5
                //[HttpDelete("{itemNumber}")]
                //public void Delete(int itemNumber)
                Console.WriteLine("-----------------------------");
                Console.WriteLine("HttpDelete {itemNumber}");
                Console.WriteLine("-----------------------------");


                WebAPIResponseMessage = await WebAPIClient.DeleteAsync("/api/Items/5");

                if (WebAPIResponseMessage.IsSuccessStatusCode)
                {
                    Console.WriteLine(WebAPIResponseMessage.StatusCode + " - Delete successful");
                }
                else
                {
                    Console.WriteLine(WebAPIResponseMessage.StatusCode + " - Delete not successful");
                }
                 // GET: api/<ItemsController>
                //[HttpGet]
                //public List<Item> Get() //method
                Console.WriteLine("-----------");
                Console.WriteLine("HttpGet");
                Console.WriteLine("------------");

                WebAPIResponseMessage = await WebAPIClient.GetAsync("/api/Items");

                WebAPIGetContent = await WebAPIResponseMessage.Content.ReadAsStringAsync();

                List<Item> ExampleItemsObjectCollection = JsonSerializer.Deserialize<List<Item>>(WebAPIGetContent, Options)!; //the ! help to ignore the error flag

                foreach (Item ExampleItemObject in ExampleItemsObjectCollection)
                {
                    Console.WriteLine("-");
                    Console.WriteLine(ExampleItemObject.ItemNumber);
                    Console.WriteLine(ExampleItemObject.Description);
                    Console.WriteLine(ExampleItemObject.UnitPrice);
                }







                // GET api/<ItemsController>/5
                //[HttpGet("{itemNumber}")]
                //public Item Get(int itemNumber) //method
                Console.WriteLine("----------------------------------");
                Console.WriteLine("HttpGet {itemNumber}");
                Console.WriteLine("----------------------------------");

                WebAPIResponseMessage = await WebAPIClient.GetAsync("/api/Items/2"); // you can modify thsi hardcodded 2 to make it dynamic.

                WebAPIGetContent = await WebAPIResponseMessage.Content.ReadAsStringAsync();

                Item ExampleItem = JsonSerializer.Deserialize<Item>(WebAPIGetContent, Options)!;

                Console.WriteLine("-");
                Console.WriteLine(ExampleItem.ItemNumber);
                Console.WriteLine(ExampleItem.Description);
                Console.WriteLine(ExampleItem.UnitPrice);







                // POST api/<ItemsController>
                //[HttpPost]
                //public void Post([FromBody] Item exampleItem)   //method
                Console.WriteLine("------------");
                Console.WriteLine("HttpPost");
                Console.WriteLine("------------");


                ExampleItem.ItemNumber = 5; // note needed for IDENTITY column 
                ExampleItem.Description = "HttpPost Insert Description";
                ExampleItem.UnitPrice = (decimal)1.11; // casted intor a decimal


                SerializedJson = JsonSerializer.Serialize(ExampleItem);

                WebAPIPostPutContent = new StringContent(SerializedJson, System.Text.Encoding.UTF8, "application/json");

                WebAPIResponseMessage = await WebAPIClient.PostAsync("/api/Items", WebAPIPostPutContent);

                if (WebAPIResponseMessage.IsSuccessStatusCode)
                {
                    Console.WriteLine(WebAPIResponseMessage.StatusCode + " - Insert successful");
                }
                else
                {
                    Console.WriteLine(WebAPIResponseMessage.StatusCode + " - Insert not successful");
                }









                // PUT api/<ItemsController>/5
                //[HttpPut("{itemNumber}")]
                //public void Put(int itemNumber, [FromBody] Item exampleItem)      //method
                Console.WriteLine("-----------------------------");
                Console.WriteLine("HttpPut {itemNumber}");
                Console.WriteLine("-----------------------------");


                ExampleItem.ItemNumber = 4; // note needed for IDENTITY column 
                ExampleItem.Description = "HttpPost update Description";
                ExampleItem.UnitPrice = (decimal)14.11; // casted intor a decimal

                SerializedJson = JsonSerializer.Serialize(ExampleItem);
                WebAPIPostPutContent = new StringContent(SerializedJson, System.Text.Encoding.UTF8, "application/json");

                WebAPIResponseMessage = await WebAPIClient.PutAsync("/api/Items/4", WebAPIPostPutContent);

                if (WebAPIResponseMessage.IsSuccessStatusCode)
                {
                    Console.WriteLine(WebAPIResponseMessage.StatusCode + " - Update successful");
                }
                else
                {
                    Console.WriteLine(WebAPIResponseMessage.StatusCode + " - Update not successful");
                }









                // DELETE api/<ItemsController>/5
                //[HttpDelete("{itemNumber}")]
                //public void Delete(int itemNumber)
                Console.WriteLine("-----------------------------");
                Console.WriteLine("HttpDelete {itemNumber}");
                Console.WriteLine("-----------------------------");


                WebAPIResponseMessage = await WebAPIClient.DeleteAsync("/api/Items/5");

                if (WebAPIResponseMessage.IsSuccessStatusCode)
                {
                    Console.WriteLine(WebAPIResponseMessage.StatusCode + " - Delete successful");
                }
                else
                {
                    Console.WriteLine(WebAPIResponseMessage.StatusCode + " - Delete not successful");
                }




            }
        }
    }
}
