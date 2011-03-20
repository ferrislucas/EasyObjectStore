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

			var idProperty = t.GetProperty("Id", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
			var idField = t.GetField("Id", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);

			if (idProperty != null) return "Id";
			if (idField != null) return "Id";

			throw new Exception(string.Format("EasyObjectStore was not able to determine what property or field to use for class: {0}", t.FullName));
		}
	}
}
