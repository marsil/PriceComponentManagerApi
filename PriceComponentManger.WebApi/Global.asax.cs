﻿using System;
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
    }
}
