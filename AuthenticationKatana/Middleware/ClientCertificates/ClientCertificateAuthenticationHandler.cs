using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Infrastructure;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Web;
using Thinktecture.IdentityModel;

namespace AuthenticationKatana.Middleware.ClientCertificates
{
	public class ClientCertificateAuthenticationHandler : AuthenticationHandler<ClientCertificateAuthenticationOptions>
	{
		private ClientCertificateAuthenticationOptions _options;

		public ClientCertificateAuthenticationHandler(ClientCertificateAuthenticationOptions options)
		{
			_options = options;
		}

		protected override System.Threading.Tasks.Task<Microsoft.Owin.Security.AuthenticationTicket> AuthenticateCoreAsync()
		{
			var cert = Context.Get<X509Certificate2>("ssl.ClientCertificate");

			if (cert == null)
			{
				return Task.FromResult<AuthenticationTicket>(null);
			}
			try
			{
				Options.Validator.Validate(cert);
			}
			catch (SecurityTokenValidationException)
			{
				return Task.FromResult<AuthenticationTicket>(null);
			}
			var identity = Identity.CreateFromCertificate(cert, Options.AuthenticationType, Options.CreateExtendedClaimSet);

			var ticket = new AuthenticationTicket(identity, new AuthenticationProperties());
			return Task.FromResult<AuthenticationTicket>(ticket);
		}
	}
}