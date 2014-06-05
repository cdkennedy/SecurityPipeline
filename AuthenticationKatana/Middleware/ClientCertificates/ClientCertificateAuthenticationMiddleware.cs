using Microsoft.Owin;
using Microsoft.Owin.Security.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace AuthenticationKatana.Middleware.ClientCertificates
{
	public class ClientCertificateAuthenticationMiddleware : AuthenticationMiddleware<ClientCertificateAuthenticationOptions>
	{
		public ClientCertificateAuthenticationMiddleware(OwinMiddleware next, X509RevocationMode revokationMode)
			: base(next, new ClientCertificateAuthenticationOptions())
		{

		}

		protected override AuthenticationHandler<ClientCertificateAuthenticationOptions> CreateHandler()
		{
			return new ClientCertificateAuthenticationHandler(Options);
		}
	}
}