using System.Linq;
using AutoMoq;
using EasyObjectStore.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace EasyObjectStore.Tests
{
	[TestClass]
	public class ObjectStoreTests_GetAll
	{
		private AutoMoqer mocker;

		[TestInitialize]
		public void Init()
		{
			mocker = new AutoMoqer();
			mocker.GetMock<IFileSystem>().Setup(a => a.DirectoryExists(It.IsAny<string>()))
				.Returns(true);
		}

		[TestMethod]
		public void Returns_deserialized_instances_from_file_system()
		{
			mocker.GetMock<IGetDataPathForType>()
				.Setup(a => a.GetPathForDataByType(typeof(DataClass)))
				.Returns("/path/");
			mocker.GetMock<IFileSystem>()
				.Setup(a => a.GetFiles("/path/", "*.xml"))
				.Returns(new string[]
				         	{
				         		"/path/1.xml",
								"/path/2.xml",
							});
			mocker.GetMock<IXmlFileSerializationHelper>()
				.Setup(a => a.DeserializeFromPath<DataClass>("/path/1.xml"))
				.Returns(new DataClass()
				         	{
				         		Id = "1",
				         	});
			mocker.GetMock<IXmlFileSerializationHelper>()
				.Setup(a => a.DeserializeFromPath<DataClass>("/path/2.xml"))
				.Returns(new DataClass()
				{
					Id = "2",
				});

			var results = mocker.Resolve<EasyObjectStore<DataClass>>().GetAll();

			Assert.AreEqual(2, results.Count());
			Assert.AreEqual(1, results.Where(a => a.Id == "1").Count());
			Assert.AreEqual(1, results.Where(a => a.Id == "2").Count());
		}

		[TestMethod]
		public void Returns_empty_set_when_repository_directory_is_not_on_filesystem()
		{
			mocker.GetMock<IGetDataPathForType>()
				.Setup(a => a.GetPathForDataByType(typeof(DataClass)))
				.Returns("/path/");
			mocker.GetMock<IFileSystem>().Setup(a => a.DirectoryExists("/path"))
				.Returns(false);

			var results = mocker.Resolve<EasyObjectStore<DataClass>>().GetAll();

			Assert.AreEqual(0, results.Count());
		}

		[TestMethod]
		public void Does_not_attempt_to_enumerate_files_when_the_folder_does_not_exist_on_the_file_system()
		{
			mocker.GetMock<IGetDataPathForType>()
				.Setup(a => a.GetPathForDataByType(typeof(DataClass)))
				.Returns("/path/");
			mocker.GetMock<IFileSystem>().Setup(a => a.DirectoryExists("/path/"))
				.Returns(false);

			mocker.Resolve<EasyObjectStore<DataClass>>().GetAll();

			mocker.GetMock<IFileSystem>().Verify(a => a.GetFiles(It.IsAny<string>(), It.IsAny<string>()), Times.Never());
		}
	}
}
