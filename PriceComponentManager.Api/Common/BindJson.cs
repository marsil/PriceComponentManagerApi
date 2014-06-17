using System;
using System.Net.Http;
using System.Web.Http.Controllers;
using Newtonsoft.Json;

namespace PriceComponentManager.Api.Common
{
	public class BindJson : System.Web.Http.Filters.ActionFilterAttribute
	{
		private readonly Type type;

		public BindJson(Type type)
		{
			this.type = type;
		}

		public override void OnActionExecuting(HttpActionContext actionContext)
		{
			var json = actionContext.Request.RequestUri.ParseQueryString()["json"];
			actionContext.ActionArguments["filters"] = JsonConvert.DeserializeObject(json, this.type);
		}
	}
}