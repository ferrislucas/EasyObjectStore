using System.Reflection;

namespace EasyObjectStore.Helpers
{
	public interface IGetValueOfIdPropertyForInstance
	{
		string GetId(object o);
	}

	public class GetValueOfIdPropertyForInstance : IGetValueOfIdPropertyForInstance
	{
		private readonly IGetNameOfIdPropertyForType getNameOfIdPropertyForType;

		public GetValueOfIdPropertyForInstance(IGetNameOfIdPropertyForType getNameOfIdPropertyForType)
		{
			this.getNameOfIdPropertyForType = getNameOfIdPropertyForType;
		}

		public string GetId(object o)
		{
			string returnValue = null;

			var nameOfIdPropertyFieldOrProperty = getNameOfIdPropertyForType.GetNameOfIdProperty(o.GetType());
			var idPropertyInformation = o.GetType().GetProperty(nameOfIdPropertyFieldOrProperty, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
			
			if (idPropertyInformation == null)
			{
				return o.GetType().GetField(nameOfIdPropertyFieldOrProperty, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public).GetValue(o).ToString();
			}

			return idPropertyInformation.GetValue(o, null).ToString();
		}
	}
}