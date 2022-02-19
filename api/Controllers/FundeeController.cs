using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using api.Repo;
using api.Models;
namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FundeeController : ControllerBase
    {
        private readonly IRepo<FundReceiver> fr;
        public FundeeController(IRepo<FundReceiver> repo)
        {
            fr = repo;
        }
        // GET: api/<FunderController>
        [HttpGet]
        public IEnumerable<FundReceiver> Get()
        {
            return fr.Get();
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public FundReceiver Get(string id)
        {
            return fr.GetById(id);
        }

        // POST api/<ProductController>
        [HttpPost]
        public void Post([FromBody] FundReceiver f)
        {
            fr.Add(f);
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] FundReceiver f)
        {
            fr.Delete(id);
            fr.Add(f);
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            fr.Delete(id);
        }
    }
}
