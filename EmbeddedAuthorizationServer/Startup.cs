using EmbeddedAuthorizationServer.App_Start;
using EmbeddedAuthorizationServer.Provider;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace EmbeddedAuthorizationServer
{
	public class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			app.UseOAuthAuthorizationServer(new OAuthAuthorizationServerOptions
				{
					AllowInsecureHttp = true,
					TokenEndpointPath = new PathString("/token"),
					AccessTokenExpireTimeSpan = TimeSpan.FromHours(8),
					Provider = new SimpleAuthorizationServerProvider(),
					RefreshTokenProvider = new SimpleRefreshTokenProvider()
				});

			app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

			app.UseWebApi(WebApiConfig.Register());
		}
	}
}