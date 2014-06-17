using Newtonsoft.Json;

using PriceComponentManager.Api.Domain;

namespace PriceComponentManager.Api.Models
{
	public class ModelFactory
	{
		public static T GetInstance<T>(string data) where T : AggragateRootImpl, new()
		{
			 return JsonConvert.DeserializeObject<T>(data);
		}
	}
}