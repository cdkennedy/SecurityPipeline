﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AuthenticationKatana.Controllers
{
    public class TestController : ApiController
    {
		public string Get()
		{
			return "working";
		}
    }
}
