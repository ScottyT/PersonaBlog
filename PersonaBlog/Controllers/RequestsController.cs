using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PersonaBlog.Models;
using PersonaBlog.Repository.Abstraction;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PersonaBlog.Controllers
{
    [Route("api/[controller]")]
    public class RequestsController : Controller
    {
        private IRepositoryWrapper _repoWrapper;
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var requests = _repoWrapper.Requests.GetAll();

            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}", Name = "RequestById")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]RequestsModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _repoWrapper.Requests.CreateRequest(model);
            _repoWrapper.Save();
            return CreatedAtAction("RequestById", new { id = model.Id }, model);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
