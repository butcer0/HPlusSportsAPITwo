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
    public class SalespersonController : Controller
    {
        private ISalespersonRepository SalespersonItems { get; set; }

        public SalespersonController(ISalespersonRepository salespersonItems)
        {
            SalespersonItems = salespersonItems;
        }

        [HttpGet]
        public IEnumerable<Salesperson> GetAll() => SalespersonItems.GetAll();

        [HttpGet("{id}", Name = "GetSalesperson")]
        public IActionResult Get(int id)
        {
            var Salesperson = SalespersonItems.Find(id);
            return new ObjectResult(Salesperson);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Salesperson value)
        {
            SalespersonItems.Add(value);
            return CreatedAtRoute("GetSalesperson", new { controller = "Salesperson", id = value.SalespersonId }, value);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Salesperson value)
        {
            var Salesperson = SalespersonItems.Find(id);
            SalespersonItems.Update(value);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            SalespersonItems.Remove(id);
        }
    }
}
