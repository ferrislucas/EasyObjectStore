using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using EasyObjectStore.Helpers;

namespace EasyObjectStore
{
	public static class EasyObjectStoreFactory<T>
	{
		public static EasyObjectStore<T> GetInstance()
		{
			return new EasyObjectStore<T>(new XmlFileSerializationHelper(), 
											new GetDataPathForType(new GetPathToDataDirectoryService(new ApplicationSettingsValueGetter())), 
											new GetValueOfIdPropertyForInstance(new GetNameOfIdPropertyForType()), 
											new GuidGetter(), 
											new FileSystem(), 
											new SetValueOfIdProperty(new GetNameOfIdPropertyForType()));
		}

		public static EasyObjectStore<T> GetInstance(string pathToDataDirectory)
		{
			return new EasyObjectStore<T>(new XmlFileSerializationHelper(),
											new GetDataPathForType(new GetHardCodedPathToDataDirectoryService(pathToDataDirectory)),
											new GetValueOfIdPropertyForInstance(new GetNameOfIdPropertyForType()),
											new GuidGetter(),
											new FileSystem(),
											new SetValueOfIdProperty(new GetNameOfIdPropertyForType()));
		}

		private class GetHardCodedPathToDataDirectoryService : IGetPathToDataDirectoryService
		{
			private readonly string pathToDataDirectory;

			public GetHardCodedPathToDataDirectoryService(string pathToDataDirectory)
			{
				this.pathToDataDirectory = pathToDataDirectory;
			}

			public string GetPathToDirectory()
			{
				return pathToDataDirectory.EndsWith(Path.DirectorySeparatorChar.ToString()) ? pathToDataDirectory : pathToDataDirectory + Path.DirectorySeparatorChar;
			}
		}
	}
}
