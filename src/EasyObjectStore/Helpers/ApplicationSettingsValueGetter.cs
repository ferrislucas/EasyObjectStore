using System.Configuration;

namespace EasyObjectStore.Helpers
{
	public interface IApplicationSettingsValueGetter
	{
		string GetValue(string key);
	}

	public class ApplicationSettingsValueGetter : IApplicationSettingsValueGetter
	{
		public string GetValue(string key)
		{
			return ConfigurationManager.AppSettings[key];
		}
	}
}
