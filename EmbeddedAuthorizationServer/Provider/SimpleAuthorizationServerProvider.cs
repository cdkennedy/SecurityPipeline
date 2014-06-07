using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace EmbeddedAuthorizationServer.Provider
{
	public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
	{
		public override async System.Threading.Tasks.Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
		{
			string id, secret;
			if (context.TryGetBasicCredentials(out id, out secret))
			{
				if (secret == "secret")
				{
					context.Validated();
				}
			}
		}

		public override async System.Threading.Tasks.Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
		{
			if (context.UserName != context.Password)
			{
				context.Rejected();
				return;
			}

			var id = new ClaimsIdentity(context.Options.AuthenticationType);
			id.AddClaim(new Claim("sub", context.UserName));
			id.AddClaim(new Claim("role", "user"));

			var props = new AuthenticationProperties(new Dictionary<string, string>
			{
				{"as:client_id", context.ClientId}
			});

			var ticket = new AuthenticationTicket(id, props);
			context.Validated(id);
		}

		public override async System.Threading.Tasks.Task GrantRefreshToken(OAuthGrantRefreshTokenContext context)
		{
			var originalClient = context.Ticket.Properties.Dictionary["as:client_id"];
			var currentClient = context.ClientId;

			if (originalClient != currentClient)
			{
				context.Rejected();
				return;
			}

			var newId = new ClaimsIdentity(context.Ticket.Identity);
			newId.AddClaim(new Claim("newClaim", "refreshToken"));

			var newTicket = new AuthenticationTicket(newId, context.Ticket.Properties);
			context.Validated(newTicket);
		}
	}
}