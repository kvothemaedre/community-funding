using sapi.Models;
using sapi.Repo;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace sapi.Controllers
{
    [Route("sapi/[controller]")]
    [ApiController]
    public class FunderCauseController : ControllerBase
    {
        private readonly ICRepo<FunderCause> fr;
        
        public FunderCauseController(ICRepo<FunderCause> repo)
        {
            fr = repo;
        }
        // GET: api/<FunderController>
        [HttpGet]
        public IEnumerable<FunderCause> Get()
        {
            return fr.Get();
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public FunderCause Get(int id)
        {
            return fr.GetById(id);
        }

        // POST api/<ProductController>
        [HttpPost]
        public void Post([FromBody] FunderCause f)
        {
            fr.Add(f);
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] FunderCause f)
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
