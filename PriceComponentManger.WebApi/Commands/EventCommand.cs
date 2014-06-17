using PriceComponentManager.Database.Dto;
using PriceComponentManger.WebApi.Configuration;

namespace PriceComponentManger.WebApi.Commands
{
	public class EventCommand<T> : ICommand where T : IHaveUniqueId
	{
		public EventDto<T> EventDto { get; private set; }

		public EventCommand(EventDto<T> eventDto)
		{
			this.EventDto = eventDto;
		}

		public async void Execute()
		{
			ServiceProvider<T>.EventRepository.Add(EventDto);
			ServiceProvider<T>.DataRepository.Apply(EventDto);
			await ServiceProvider<T>.Database.AddEvent(EventDto);
		}
	}
}