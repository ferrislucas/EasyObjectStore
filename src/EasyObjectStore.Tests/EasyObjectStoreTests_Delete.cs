using AutoMoq;
using EasyObjectStore.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace EasyObjectStore.Tests
{
	[TestClass]
	public class EasyObjectStoreTests_Delete
	{
		private AutoMoqer mocker;

		[TestInitialize]
		public void Init()
		{
			mocker = new AutoMoqer();
		}

		[TestMethod]
		public void Calls_Delete_method_of_IFileSystem_with_correct_path_when_the_file_exists()
		{
			mocker.GetMock<IFileSystem>().Setup(a => a.FileExists("/path/id.xml")).Returns(true);
			mocker.GetMock<IGetDataPathForType>().Setup(a => a.GetPathForDataByType(typeof(DataClass)))
				.Returns("/path/");

			mocker.Resolve<EasyObjectStore<DataClass>>().Delete("id");

			mocker.GetMock<IFileSystem>()
				.Verify(a => a.DeleteFile("/path/id.xml"), Times.Once());
		}

		[TestMethod]
		public void Does_not_call_Delete_method_of_IFileSystem_with_correct_path_when_the_file_does_not_exist()
		{
			mocker.GetMock<IFileSystem>().Setup(a => a.FileExists("/path/id.xml")).Returns(false);
			mocker.GetMock<IGetDataPathForType>().Setup(a => a.GetPathForDataByType(typeof(DataClass)))
				.Returns("/path/");

			mocker.Resolve<EasyObjectStore<DataClass>>().Delete("id");

			mocker.GetMock<IFileSystem>()
				.Verify(a => a.DeleteFile("/path/id.xml"), Times.Never());
		}
	}
}
