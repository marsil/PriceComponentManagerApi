using PriceComponentManager.Database.Dto;
using PriceComponentManger.WebApi.Configuration;

namespace PriceComponentManger.WebApi.Commands.Base
{
	public class EventCommand<T> : ICommand where T : IHaveUniqueId
	{
		public EventDto<T> EventDto { get; private set; }

		public EventCommand(EventDto<T> eventDto)
		{
			this.EventDto = eventDto;
		}

		public void Execute()
		{
			ServiceProvider.GetEventRepository<T>().Add(this.EventDto);
			ServiceProvider.GetDataRepository<T>().Apply(this.EventDto);
			ServiceProvider.Database.AddEvent(this.EventDto);
		}
	}
}