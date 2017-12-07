using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CareOptimizationServices.Controllers
{
    public class CareCoachController : ApiController
    {
        public IHttpActionResult Get()
        {
            return Ok("care coach list response!");
        }
    }
}
