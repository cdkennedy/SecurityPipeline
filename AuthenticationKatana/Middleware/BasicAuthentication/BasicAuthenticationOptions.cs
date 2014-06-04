using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuthenticationKatana.Middleware.BasicAuthentication
{
	public class BasicAuthenticationOptions : AuthenticationOptions
	{
		public BasicAuthenticationMiddleware.CredentialValidationFunction CredentialValidationFunction { get; private set; }
		public string Realm { get; private set; }

		public BasicAuthenticationOptions(string realm, 
			BasicAuthenticationMiddleware.CredentialValidationFunction credentialValidationFunction)
			:base("Basic")
		{
			Realm = realm;
			CredentialValidationFunction = credentialValidationFunction;
		}
	}
}