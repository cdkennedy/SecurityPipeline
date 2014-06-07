using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace EmbeddedAuthorizationServer.App_Start
{
	public class WebApiConfig
	{
		public static HttpConfiguration Register()
		{
			var configuration = new HttpConfiguration();
			configuration.Routes.MapHttpRoute(
				"default",
				"api/{controller}");

			return configuration;
		}
	}
}