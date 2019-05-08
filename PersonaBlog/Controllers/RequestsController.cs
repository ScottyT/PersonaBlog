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
    [ApiController]
    public class RequestsController : ControllerBase
    {
        private readonly IRepositoryWrapper _repoWrapper;
        public RequestsController(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }
        // GET: api/<controller>
        [HttpGet]
        public IActionResult Get()
        {
            var requests = _repoWrapper.Requests.GetAll();

            return Ok(requests);
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
            model.UserId = User.Claims.SingleOrDefault(u => u.Type == "uid")?.Value;
            _repoWrapper.Requests.CreateRequest(model);
            _repoWrapper.Save();
            return Created($"api/requests/{model.Id}", model);
            //return CreatedAtAction("RequestById", new { id = model.Id }, model);
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
