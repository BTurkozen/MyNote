using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyNote.Api.Controllers
{
    public class TestController : ApiController
    {
        //api/Test/
        [HttpGet]
        public DateTime Time()
        {
            return DateTime.Now;
        }
    }
}
