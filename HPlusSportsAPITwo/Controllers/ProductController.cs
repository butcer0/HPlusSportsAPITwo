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
    public class ProductController : Controller
    {
        private IProductRepository ProductItems { get; set; }

        public ProductController(IProductRepository productItems)
        {
            ProductItems = productItems;
        }

        [HttpGet]
        public IEnumerable<Product> GetAll() => ProductItems.GetAll();

        [HttpGet("{id}", Name = "GetProduct")]
        public IActionResult Get(string id)
        {
            var Product = ProductItems.Find(id);
            return new ObjectResult(Product);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Product value)
        {
            ProductItems.Add(value);
            return CreatedAtRoute("GetProduct", new { controller = "Product", id = value.ProductId }, value);
        }

        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody]Product value)
        {
            var Product = ProductItems.Find(id);
            ProductItems.Update(value);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            ProductItems.Remove(id);
        }
    }
}
