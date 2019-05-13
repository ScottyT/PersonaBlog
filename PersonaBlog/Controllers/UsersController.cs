using Microsoft.AspNetCore.Mvc;
using PersonaBlog.Models;
using Okta.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Okta.Sdk.Configuration;

namespace PersonaBlog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private OktaClient client;
        public UsersController()
        {
            client = new OktaClient(new OktaClientConfiguration
            {
                OktaDomain = "https://dev-616356.okta.com/",
                Token = "00EEpK-7PR6vFh3tpqaiG_NBwjKeItSCTdilh-bQnW"
            });
        }
        //public IActionResult Get()
        //{
        //    var user = client.Users.GetUserAsync()
        //    return Ok(user);
        //}
        [HttpPost]
        public async void Post([FromBody]Registration reg)
        {
            var oktaClient = new OktaClient();
            var user = await oktaClient.Users.CreateUserAsync(
                new CreateUserWithPasswordOptions
                {
                    Profile = new UserProfile
                    {
                        FirstName = reg.FirstName,
                        LastName = reg.LastName,
                        Email = reg.Email,
                        Login = reg.Email,
                    },
                    Password = reg.Password,
                    Activate = true,
                }
            );
        }
    }
}
