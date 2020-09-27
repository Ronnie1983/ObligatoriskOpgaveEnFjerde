using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OpgaveEtLib.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ObligatoriskOpgaveEnFjerdeServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BikesController : ControllerBase
    {
        private static int number = 0;
        //Data
        private static List<Cykel> Bikes = new List<Cykel>()
        {
            new Cykel(CreateId(), "Red", 50, 5),
            new Cykel(CreateId(), "Blå", 1500, 3),
            new Cykel(CreateId(), "Sort", 2500, 15),
            new Cykel(CreateId(), "Hvid", 2000, 5),
            new Cykel(CreateId(), "Sort", 8000, 24)
        };

        private static int CreateId()
        {
            number = number + 1;

            return number;
        }

        // GET: api/<BikeController>
        [HttpGet]
        public IEnumerable<Cykel> Get()
        {
            return Bikes;
        }

        // GET api/<BikeController>/5
        [HttpGet("{id}")]
        public Cykel Get(int id)
        {
            return Bikes.Find(b=>b.Id == id);
        }

        // POST api/<BikeController>
        [HttpPost]
        public void Post([FromBody] Cykel value)
        {
            Bikes.Add(value);
        }

        // PUT api/<BikeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Cykel value)
        {
            Cykel bike = Get(id);
            if (bike != null)
            {
                bike.Id = value.Id;
                bike.Farve = value.Farve;
                bike.Price = value.Price;
                bike.Gear = value.Gear;
            }
        }

        // DELETE api/<BikeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Cykel bike = Get(id);
            Bikes.Remove(bike);
        }
    }
}
