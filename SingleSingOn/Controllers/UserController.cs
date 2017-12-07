using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SingleSingOn.Controllers
{
    public class UserController : ApiController
    {
        // GET: User
        public IHttpActionResult Get()
        {
            return Ok("User response");
        }
    }
}