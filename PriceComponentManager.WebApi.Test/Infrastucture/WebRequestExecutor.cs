using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace PriceComponentManager.WebApi.Test.Infrastucture
{
	public class WebRequestExecutor
	{
		public static T SendRequest<T>(string url) where T : new()
		{
			var apiUrl = GetWebApiBaseUrl();
			url = apiUrl + url;

			var request = (HttpWebRequest)WebRequest.Create(url);
			var response = (HttpWebResponse)request.GetResponse();

			if (response.StatusCode == HttpStatusCode.OK)
			{
				var responseStream = response.GetResponseStream();
				if (responseStream != null)
				{
					var streamReader = new StreamReader(responseStream, Encoding.UTF8);

					var text = streamReader.ReadToEnd();

					response.Close();
					streamReader.Close();

					return JsonConvert.DeserializeObject<T>(text);
				}
			}
			
			return new T();
		}

		public static string PostData<T>(string url, T data)
		{
			var apiUrl = GetWebApiBaseUrl();
			url = apiUrl + url;

			var webRequest = WebRequest.Create(url);
			webRequest.Method = "POST";
			webRequest.ContentType = "text/json";

			using(var streamWriter = new StreamWriter(webRequest.GetRequestStream()))
			{
				var json = JsonConvert.SerializeObject(data);
				streamWriter.Write(json);
				streamWriter.Flush();
			}

			try
			{
				return ReadFromStream(webRequest.GetResponse());
			}
			catch(WebException e)
			{
				return ReadFromStream(e.Response);
			}
		}

		private static string ReadFromStream(WebResponse response)
		{
			using (var stream = response.GetResponseStream())
			{
				if (stream == null)
				{
					return null;
				}

				using (var streamReader = new StreamReader(stream))
				{
					return streamReader.ReadToEnd();
				}
			}
		}

		private static string GetWebApiBaseUrl()
		{
			return ConfigurationManager.AppSettings.Get("PriceComponentManagerApi");
		}

		//public static async Task<object> SendRequest<T>(string url)
		//{
		//	using (var client = new HttpClient())
		//	{
		//		var apiUrl = ConfigurationManager.AppSettings.Get("PriceComponentManagerApi");
		//		client.BaseAddress = new Uri(apiUrl);
		//		client.DefaultRequestHeaders.Accept.Clear();
		//		client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
		//		// New code:
		//		var httpResponseMessage = await client.GetAsync(url);
		//		if (httpResponseMessage.IsSuccessStatusCode)
		//		{
		//			var result = httpResponseMessage.Content.ReadAsAsync<T>().Result;
		//			//return new OkNegotiatedContentResult<T>(result);
		//			return result;
		//		}
		//	}

		//	return null;
		//}
	}
}
