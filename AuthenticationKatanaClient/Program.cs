using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Thinktecture.IdentityModel;

namespace AuthenticationKatanaClient
{
	class Program
	{
		static void Main(string[] args)
		{
			//var handler = new WebRequestHandler();
			//handler.ClientCertificates.Add(X509.CurrentUser.My.SubjectDistinguishedName("CN=clinet").First());

			////var handler = new HttpClientHandler
			////{
			//	//ClientCertificateOptions = ClientCertificateOption.Automatic
			////};

			//var client = new HttpClient(handler)
			//{
			//	BaseAddress = new Uri("https://localhost:44301/api/")
			//};

			//client.SetBasicAuthentication("dom", "dom");


			//var response = client.GetAsync("identity").Result;
			//response.EnsureSuccessStatusCode();

			//var content = response.Content.ReadAsStringAsync().Result;
			//Console.WriteLine(content);
		}
	}
}
