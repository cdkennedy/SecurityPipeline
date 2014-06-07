using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Infrastructure;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmbeddedAuthorizationServer.Provider
{
	public class SimpleRefreshTokenProvider : IAuthenticationTokenProvider
	{
		private static ConcurrentDictionary<string, AuthenticationTicket> _refreshTokens;

		public void Create(AuthenticationTokenCreateContext context)
		{
			throw new NotImplementedException();
		}

		public async System.Threading.Tasks.Task CreateAsync(AuthenticationTokenCreateContext context)
		{
			var guid = Guid.NewGuid().ToString();

			var refreshTokenProperties = new AuthenticationProperties(context.Ticket.Properties.Dictionary)
			{
				IssuedUtc = context.Ticket.Properties.IssuedUtc,
				ExpiresUtc = DateTime.UtcNow.AddYears(1)
			};
			var refreshTokenTicket = new AuthenticationTicket(context.Ticket.Identity, refreshTokenProperties);

			_refreshTokens.TryAdd(guid, refreshTokenTicket);
			context.SetToken(guid);
		}

		public void Receive(AuthenticationTokenReceiveContext context)
		{
			AuthenticationTicket ticket;
			if (_refreshTokens.TryRemove(context.Token, out ticket))
			{
				context.SetTicket(ticket);
			}
		}

		public System.Threading.Tasks.Task ReceiveAsync(AuthenticationTokenReceiveContext context)
		{
			throw new NotImplementedException();
		}
	}
}