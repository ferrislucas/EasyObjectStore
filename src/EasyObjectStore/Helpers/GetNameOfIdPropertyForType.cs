using System;
using System.Reflection;

namespace EasyObjectStore.Helpers
{
	public interface IGetNameOfIdPropertyForType
	{
		string GetNameOfIdProperty(Type t);
	}

	public class GetNameOfIdPropertyForType : IGetNameOfIdPropertyForType
	{
		public string GetNameOfIdProperty(Type t)
		{
			var keyProperty = t.GetProperty("Key", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
			var keyField = t.GetField("Key", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);

			if (keyProperty != null) return "Key";
			if (keyField != null) return "Key";

			return "Id";
		}
	}
}
