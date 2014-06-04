﻿using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using AuthenticationKatana.Middleware.BasicAuthentication;
using System.Threading.Tasks;
using System.Security.Claims;

namespace AuthenticationKatana
{
	public class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			var configuration = new HttpConfiguration();
			configuration.Routes.MapHttpRoute(
				"default",
				"api/{controller}");

			app.UseBasicAuthentication("Demo", ValidateUsers);
			app.UseWebApi(configuration);
		}

		private Task<IEnumerable<Claim>> ValidateUsers(string id, string secret)
		{
			if (id == secret)
			{
				var claims = new List<Claim>
				{
					new Claim(ClaimTypes.NameIdentifier,id),
					new Claim(ClaimTypes.Role,"foo")
				};
				return Task.FromResult<IEnumerable<Claim>>(claims);
			}

			return Task.FromResult<IEnumerable<Claim>>(null);
		}
	}
}