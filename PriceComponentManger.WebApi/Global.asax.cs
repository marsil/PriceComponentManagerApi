using System;
using System.Diagnostics;
using System.Web.Http;

namespace PriceComponentManger.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }

		protected void Application_BeginRequest(object sender, EventArgs e)
		{
		}

		protected void Application_Error(object sender, EventArgs e)
		{
			//get reference to the source of the exception chain
			var exception = Server.GetLastError().GetBaseException();

			//log the details of the exception and page state to the
			//Windows 2000 Event Log
			EventLog.WriteEntry("Test Web",
			  "MESSAGE: " + exception.Message +
			  "\nSOURCE: " + exception.Source +
			  "\nFORM: " + Request.Form.ToString() +
			  "\nQUERYSTRING: " + Request.QueryString.ToString() +
			  "\nTARGETSITE: " + exception.TargetSite +
			  "\nSTACKTRACE: " + exception.StackTrace,
			  EventLogEntryType.Error);

			//Insert optional email notification here...
		}
    }
}
