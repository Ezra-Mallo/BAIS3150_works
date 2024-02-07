using BAIS3150ASPNETCoreEmptyWebAPI.Models;
using BAIS3150ASPNETCoreEmptyWebAPI.TechnicalServices;
using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BAIS3150ASPNETCoreEmptyWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        // GET: api/<ItemsController>
        [HttpGet]
        public List<Item> Get() //method
        {
            Items ItemManager = new();
            List<Item> ExampleItems = ItemManager.GetItems();
            return ExampleItems;

        }







        // GET api/<ItemsController>/5
        [HttpGet("{itemNumber}")]
        public Item Get(int itemNumber) //method
        {

            Items ItemManager = new();
            Item ExampleItem = ItemManager.GetItem(itemNumber);

            return ExampleItem;

        }





        // POST api/<ItemsController>
        [HttpPost]
        public void Post([FromBody] Item exampleItem)   //method
        {
            Items ItemManager = new();
            ItemManager.AddItem(exampleItem);
        }





        // PUT api/<ItemsController>/5
        [HttpPut("{itemNumber}")]
        public void Put(int itemNumber, [FromBody] Item exampleItem)      //method
        {
            Items ItemManager = new();
            ItemManager.UpdateItem(itemNumber, exampleItem);
        }





        // DELETE api/<ItemsController>/5
        [HttpDelete("{itemNumber}")]
        public void Delete(int itemNumber)
        {
            Items ItemManager = new();
            ItemManager.DeleteItem(itemNumber);
        }
    }
}
