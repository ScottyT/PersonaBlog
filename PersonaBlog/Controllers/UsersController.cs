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
       
        [HttpPost]
        public async void Post([FromBody]Registration reg)
        {
            
            var user = await client.Users.CreateUserAsync(
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
