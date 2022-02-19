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
    public class CauseController : ControllerBase
    {
        private readonly ICRepo<Cause> fr;
        public CauseController(ICRepo<Cause> repo)
        {
            fr = repo;
        }
        // GET: api/<FunderController>
        [HttpGet]
        public IEnumerable<Cause> Get()
        {
            return fr.Get();
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public Cause Get(int id)
        {
            return fr.GetById(id);
        }

        // POST api/<ProductController>
        [HttpPost]
        public void Post([FromBody] Cause f)
        {
            fr.Add(f);
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Cause f)
        {
            fr.Delete(id);
            fr.Add(f);
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            fr.Delete(id);
        }
    }
}
