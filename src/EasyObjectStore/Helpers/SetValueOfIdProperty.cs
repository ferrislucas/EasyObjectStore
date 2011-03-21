using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace EasyObjectStore.Helpers
{
	public interface ISetValueOfIdProperty
	{
		void SetId(object instance, object idValue);
	}

	public class SetValueOfIdProperty : ISetValueOfIdProperty
	{
		private readonly IGetNameOfIdPropertyForType getNameOfIdPropertyForType;

		public SetValueOfIdProperty(IGetNameOfIdPropertyForType getNameOfIdPropertyForType)
		{
			this.getNameOfIdPropertyForType = getNameOfIdPropertyForType;
		}

		public void SetId(object instance, object idValue)
		{
			var nameOfIdPropertyFieldOrProperty = getNameOfIdPropertyForType.GetNameOfIdProperty(instance.GetType());
			var idPropertyInformation = instance.GetType().GetProperty(nameOfIdPropertyFieldOrProperty, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);

			if (idPropertyInformation.PropertyType.FullName == "System.Guid")
			    idPropertyInformation.SetValue(instance, new Guid(idValue.ToString()), null);
			else
				idPropertyInformation.SetValue(instance, idValue, null);
		}
	}
}
