using System.IO;
using AutoMoq;
using EasyObjectStore.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EasyObjectStore.Tests.Helpers
{
	[TestClass]
	public class GetDataPathForTypeTests
	{
		private AutoMoqer mocker;

		[TestInitialize]
		public void Init()
		{
			mocker = new AutoMoqer();
		}

		[TestMethod]
		public void Returns_correct_path()
		{
			mocker.GetMock<IGetPathToDataDirectoryService>()
				.Setup(a => a.GetPathToDirectory())
				.Returns("/path/");

			var result = mocker.Resolve<GetDataPathForType>().GetPathForDataByType(typeof(string));

			Assert.AreEqual("/path/" + typeof(string).FullName + Path.DirectorySeparatorChar, result);
		}
	}
}
