using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuthenticationKatana.Middleware.BasicAuthentication
{
	public static class BasicAuthenticationExtensions
	{
		public static IAppBuilder UseBasicAuthentication(this IAppBuilder app,
			string realm, BasicAuthenticationMiddleware.CredentialValidationFunction validationFunction)
		{
			var options = new BasicAuthenticationOptions(realm, validationFunction);
			return app.UserBasicAuthentication(options);
		}

		public static IAppBuilder UserBasicAuthentication(this IAppBuilder app, BasicAuthenticationOptions options)
		{
			return app.Use<BasicAuthenticationMiddleware>(options);
		}
	}
}