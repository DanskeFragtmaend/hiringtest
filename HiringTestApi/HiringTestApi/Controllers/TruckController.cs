using System.Collections.Generic;
using System.Threading;
using HiringTestApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace HiringTestApi.Controllers
{
    [Route("api/[controller]")]
    public class TruckController : Controller
    {
        private readonly ITruckRepository truckRepository;

        public TruckController(ITruckRepository truckRepository)
        {
            this.truckRepository = truckRepository;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<Truck> Get()
        {
            Thread.Sleep(3000);
            return this.truckRepository.GetAll();
        }

        // GET api/values/HN85258
        [HttpGet("{id}")]
        public ActionResult Get(string id)
        {
            var truck = this.truckRepository.Get(id);
            if (truck == null) return NotFound();
            return Ok(truck);
        }

        // PUT api/values/as65498
        [HttpPut("{id}")]
        public void Put(string id, [FromBody]Truck value)
        {
            this.truckRepository.Update(id, value);
        }
    }
}