using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace EasyObjectStore.Helpers
{
	public interface IXmlFileSerializationHelper
	{
		void SerializeListToPath<T>(List<T> data, string path);
		List<T> DeserializeListFromPath<T>(string path);
		void SerializeToPath<T>(T data, string path);
		T DeserializeFromPath<T>(string path);
	}

	public class XmlFileSerializationHelper : IXmlFileSerializationHelper
	{
		public void SerializeToPath<T>(T data, string path)
		{
			CreateEmptyFileIfItDoesntExist<T>(path);

			var serializer = new XmlSerializer(typeof(T));
			TextWriter textWriter = new StreamWriter(path);
			serializer.Serialize(textWriter, data);
			textWriter.Close();
		}

		public T DeserializeFromPath<T>(string path)
		{
			CreateEmptyFileIfItDoesntExist<T>(path);

			var deserializer = new XmlSerializer(typeof(T));
			TextReader textReader = new StreamReader(path);
			var data = (T)deserializer.Deserialize(textReader);
			textReader.Close();

			return data;
		}

		public void SerializeListToPath<T>(List<T> data, string path)
		{
			CreateEmptyFileIfItDoesntExist<T>(path);

			var serializer = new XmlSerializer(typeof(List<T>));
			TextWriter textWriter = new StreamWriter(path);
			serializer.Serialize(textWriter, data);
			textWriter.Close();
		}

		public List<T> DeserializeListFromPath<T>(string path)
		{
			CreateEmptyFileIfItDoesntExist<T>(path);

			var deserializer = new XmlSerializer(typeof(List<T>));
			TextReader textReader = new StreamReader(path);
			var data = (List<T>)deserializer.Deserialize(textReader);
			textReader.Close();

			return data;
		}

		private void CreateEmptyFileIfItDoesntExist<T>(string path)
		{
			if (!File.Exists(path))
			{
				if (!Directory.Exists(path))
				{
					var split = path.Split(Path.DirectorySeparatorChar);
					var s = path.Replace(split[split.Length - 1], string.Empty);
					Directory.CreateDirectory(s);
				}

				using (System.IO.File.Create(path)){}

				var serializer = new XmlSerializer(typeof(List<T>));
				TextWriter textWriter = new StreamWriter(path);
				serializer.Serialize(textWriter, new List<T>());
				textWriter.Close();	
			}
		}
	}
}
