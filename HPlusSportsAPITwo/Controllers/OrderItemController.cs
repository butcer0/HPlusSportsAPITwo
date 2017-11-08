using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HPlusSportsAPITwo.Models;
using HPlusSportsAPITwo.Contracts;
using HPlusSportsAPITwo.Repositories;

namespace HPlusSportsAPITwo.Controllers
{
    [Route("api/[controller]")]
    public class OrderItemController : Controller
    {
        private IOrderItemRepository OrderItemItems { get; set; }

        public OrderItemController(IOrderItemRepository orderItemItems)
        {
            OrderItemItems = orderItemItems;
        }

        [HttpGet]
        public IEnumerable<OrderItem> GetAll() => OrderItemItems.GetAll();

        [HttpGet("{id}", Name = "GetOrderItem")]
        public IActionResult Get(int id)
        {
            var Order = OrderItemItems.Find(id);
            return new ObjectResult(Order);
        }

        [HttpPost]
        public IActionResult Post([FromBody]OrderItem value)
        {
            OrderItemItems.Add(value);
            return CreatedAtRoute("GetOrderItem", new { controller = "OrderItem", id = value.OrderItemId }, value);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]OrderItem value)
        {
            var OrderItem = OrderItemItems.Find(id);
            OrderItemItems.Update(value);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            OrderItemItems.Remove(id);
        }
    }
}
