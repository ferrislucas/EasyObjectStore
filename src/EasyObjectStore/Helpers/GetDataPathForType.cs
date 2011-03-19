using System;
using System.IO;

namespace EasyObjectStore.Helpers
{
	public interface IGetDataPathForType
	{
		string GetPathForDataByType(Type t);
	}

	public class GetDataPathForType : IGetDataPathForType
	{
		private readonly IGetPathToDataDirectoryService getPathToDataDirectoryService;

		public GetDataPathForType(IGetPathToDataDirectoryService getPathToDataDirectoryService)
		{
			this.getPathToDataDirectoryService = getPathToDataDirectoryService;
		}

		public string GetPathForDataByType(Type t)
		{
			return getPathToDataDirectoryService.GetPathToDirectory() + t + Path.DirectorySeparatorChar;
		}
	}
}
