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
    public class OrderController : Controller
    {
        private IOrderRepository OrderItems { get; set; }

        public OrderController(IOrderRepository orderItems)
        {
            OrderItems = orderItems;
        }

        [HttpGet]
        public IEnumerable<Order> GetAll() => OrderItems.GetAll();

        [HttpGet("{id}", Name = "GetOrder")]
        public IActionResult Get(int id)
        {
            var Order = OrderItems.Find(id);
            return new ObjectResult(Order);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Order value)
        {
            OrderItems.Add(value);
            return CreatedAtRoute("GetOrder", new { controller = "Order", id = value.OrderId }, value);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Order value)
        {
            var Order = OrderItems.Find(id);
            OrderItems.Update(value);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            OrderItems.Remove(id);
        }
    }
}
