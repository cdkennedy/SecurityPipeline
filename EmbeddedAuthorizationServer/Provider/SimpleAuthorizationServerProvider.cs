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
			context.Validated();
		}

		public override async System.Threading.Tasks.Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
		{
			if(context.UserName != context.Password)
			{
				context.Rejected();
				return;
			}

			var id = new ClaimsIdentity(context.Options.AuthenticationType);
			id.AddClaim(new Claim("sub", context.UserName));
			id.AddClaim(new Claim("role", "user"));

			context.Validated(id);
		}
	}
}