using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.IdentityModel.Selectors;
using System.Linq;
using System.Web;

namespace AuthenticationKatana.Middleware.ClientCertificates
{
	public class ClientCertificateAuthenticationOptions : AuthenticationOptions
	{
		public X509CertificateValidator Validator { get; set; }
		public bool CreateExtendedClaimSet { get; set; }

		public ClientCertificateAuthenticationOptions() : base("X.509")
		{
			Validator = X509CertificateValidator.ChainTrust;

			CreateExtendedClaimSet = false;
		}
	}
}