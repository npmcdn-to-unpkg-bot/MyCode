using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TLMManager.Controller
{
    public class UserController : BaseController
    {




        [HttpGet]
        public string HelloWorld()
        {
            return "HelloWorld";
        }
    }
}
