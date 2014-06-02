using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web;

namespace SecurityPipeline.Pipeline
{
	public class TestMiddleware
	{
		public TestMiddleware(Func<IDictionary<string, object>, Task> next)
		{
			_next = next;
		}
		 
		public async Task Invoke(IDictionary<string, object> env) 
		{
			var context = new OwinContext(env);

			Helper.Write("Middleware", context.Request.User);

			context.Request.User = new GenericPrincipal(new GenericIdentity("dom"), new string[] { });

			await _next(env);
		}

		public Func<IDictionary<string, object>, Task> _next { get; set; }
	}
}