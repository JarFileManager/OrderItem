using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OrderItem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;


namespace OrderItem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {   

        
        [HttpGet("{menuItemId}/{userId}")]
        public IActionResult SetCart([FromRoute] int menuItemId, int userId)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://20.84.12.180");
            string site = $"/api/MenuItem/{menuItemId}";

            HttpResponseMessage response = client.GetAsync(site).Result;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                string jsonString = response.Content.ReadAsStringAsync().Result;
                MenuItem menu = JsonConvert.DeserializeObject<MenuItem>(jsonString);

                Cart cart = new Cart
            {
                Id = 1,
                UserId = userId,
                MenuItemId = menuItemId,
                MenuItemName = menu.Name
                //MenuItemName = "Phone"
            };
            return Ok(cart);
        }
            else
            {
                return BadRequest(response.Content.ToString());
    }

}

        
    }
}
