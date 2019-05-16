using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonaBlog.Models;
using PersonaBlog.Repository.Abstraction;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PersonaBlog.Controllers
{
    [Route("api/[controller]/[action]")]
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
        [ActionName("GetRequests")]
        public IActionResult Get()
        {
            //var userId = User.Claims.SingleOrDefault(u => u.Type == "uid")?.Value;
            var requests = _repoWrapper.Requests.GetAll().ToList();

            return Ok(requests);
        }

        // POST api/<controller>
        [HttpPost]
        [ActionName("PostRequests")]
        public IActionResult Post([FromBody]RequestsModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            DateTime d = DateTime.UtcNow;
            var principal = HttpContext.User.Identity as ClaimsIdentity;
            model.UserId = principal.Claims.SingleOrDefault(u => u.Type == "uid")?.Value;
            model.DateCreated = d;
            _repoWrapper.Requests.CreateRequest(model);
            _repoWrapper.Save();
            return Created($"api/requests/{model.Id}", model);
            //return CreatedAtAction("RequestById", new { id = model.Id }, model);
        }

        [HttpPost]
        [ActionName("Accepted")]
        public IActionResult RequestAccepted([FromBody]RequestsModel model)
        {
            var request = _repoWrapper.Requests.GetSingle(r => r.Id == model.Id);
            //var accepted = model.AcceptRequest;
            //if (!accepted)
            //{
            //    return BadRequest();
            //}
            _repoWrapper.Accepted.RequestAccepted(new AcceptedRequests
            {
                Priority = 3,
                Request = request,
                RequestID = request.Id
            });
            //_repoWrapper.Requests.UpdateRequest(request);
            
            _repoWrapper.Save();
            return Created($"api/requests/{ model.Id}", model);
            //var acceptedId = Guid.NewGuid().ToString();
            //var acceptedRequest = new AcceptedRequests
            //{
            //    AcceptedId = acceptedId,
            //    Priority = 3,
            //    Request = model
            //};
            
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
