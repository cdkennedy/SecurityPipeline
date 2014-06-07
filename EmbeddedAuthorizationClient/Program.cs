using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Thinktecture.IdentityModel.Client;

namespace EmbeddedAuthorizationClient
{
	class Program
	{
		static void Main(string[] args)
		{
			var response = GetToken();
			CallService(response.AccessToken);
		}

		private static void CallService(string token)
		{
			var client = new HttpClient();
			client.SetBearerToken(token);
			var response = client.GetStringAsync(new Uri("http://localhost:50261/api/identity")).Result;

			Console.WriteLine(response);
		}

		private static TokenResponse GetToken()
		{
			var client = new OAuth2Client(
				new Uri("http://localhost:50261/token"));

			return client.RequestResourceOwnerPasswordAsync("bob", "bob").Result;
		}
	}
}
