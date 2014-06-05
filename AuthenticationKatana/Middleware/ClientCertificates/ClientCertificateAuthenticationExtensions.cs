using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace AuthenticationKatana.Middleware.ClientCertificates
{
	public static class ClientCertificateAuthenticationExtensions
	{
		public static IAppBuilder UseClientCertificateAuthentication(this IAppBuilder app, X509RevocationMode revokationMode)
		{
			return app.Use<ClientCertificateAuthenticationMiddleware>(revokationMode);
		}
	}
}