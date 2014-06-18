using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace PriceComponentManger.WebApi.Validation
{
	public class ValidateModelAttribute : ActionFilterAttribute
	{
		public override void OnActionExecuting(HttpActionContext actionContext)
		{
			foreach (var actionArgument in actionContext.ActionArguments)
			{
				if (actionArgument.Value == null)
				{
					ReturnBadArguments(actionContext, new List<string>());
				}
				else
				{
					ValidateArgument(actionContext, actionArgument.Value);
				}
			}
		}

		private static void ReturnBadArguments(HttpActionContext actionContext, List<string> args)
		{
			actionContext.Response = actionContext.Request.CreateErrorResponse(
					HttpStatusCode.BadRequest, string.Format("Parameters can not be null: " + string.Join(",", args)));
		}

		private static void ValidateArgument(HttpActionContext actionContext, object argument)
		{
			var properties = argument.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var propertyInfo in properties)
            {
	            if (propertyInfo.PropertyType.IsGenericType
	                && propertyInfo.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
	            {
					var value = propertyInfo.GetValue(argument);
		            if (value == null)
		            {
			            ReturnBadArguments(actionContext, new List<string> { propertyInfo.Name });
		            }
	            }
                
            }
		}
	}
}