using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationKatanaClient
{
	class Program
	{
		static void Main(string[] args)
		{
			var client = new HttpClient
			{
				BaseAddress = new Uri("https://localhost:44301/api/")
			};

			client.SetBasicAuthentication("dom", "dom");

			var response = client.GetAsync("identity").Result;
			response.EnsureSuccessStatusCode();

			var content = response.Content.ReadAsStringAsync().Result;
			Console.WriteLine(content);
		}
	}
}
