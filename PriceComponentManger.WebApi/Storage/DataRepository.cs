using System;
using System.Collections.Generic;
using PriceComponentManager.Database.Dto;
using PriceComponentManager.Database.Enums;

namespace PriceComponentManger.WebApi.Storage
{
	public class DataRepository<T> : IDataRepository<T>
		where T : IHaveUniqueId
	{
		private static readonly List<T> Items = new List<T>();

		public List<T> GetItems()
		{
			return Items;
		}

		public void Apply(EventDto<T> eventDto)
		{
			if(eventDto.Type == EventType.Created) this.Add(eventDto.Data);
			else if(eventDto.Type == EventType.Updated) this.Update(eventDto.Data);
			else if(eventDto.Type == EventType.Deleted) this.Delete(eventDto.Data.UniqueId);
		}

		private void Add(T data)
		{
			Items.Add(data);
		}

		private void Update(T data)
		{
			var index = Items.FindIndex(i => i.UniqueId == data.UniqueId);
			if(index != -1) Items[index] = data;
			else throw new ArgumentException("Can not update data with id: " + data.UniqueId);
		}

		private void Delete(Guid uniqueId)
		{
			var index = Items.FindIndex(i => i.UniqueId == uniqueId);
			if (index != -1) Items.RemoveAt(index);
			else throw new ArgumentException("Can not delete data with id: " + uniqueId);
		}
	}
}