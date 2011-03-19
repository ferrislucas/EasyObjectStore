using AutoMoq;
using EasyObjectStore.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EasyObjectStore.Tests.Helpers
{
	[TestClass]
	public class GetValueOfIdPropertyForInstanceTests_GetId
	{
		private AutoMoqer mocker;

		[TestInitialize]
		public void Init()
		{
			mocker = new AutoMoqer();
		}

		[TestMethod]
		public void Returns_value_of_Id_field()
		{
			mocker.GetMock<IGetNameOfIdPropertyForType>()
				.Setup(a => a.GetNameOfIdProperty(typeof(Test1)))
				.Returns("Id");

			var result = mocker.Resolve<GetValueOfIdPropertyForInstance>()
				.GetId(new Test1()
						{
							Id = "1"
						});

			Assert.AreEqual("1", result);
		}

		[TestMethod]
		public void Returns_value_of_Key_field()
		{
			mocker.GetMock<IGetNameOfIdPropertyForType>()
				.Setup(a => a.GetNameOfIdProperty(typeof(Test2)))
				.Returns("Key");

			var result = mocker.Resolve<GetValueOfIdPropertyForInstance>()
				.GetId(new Test2()
				{
					Key = 2
				});

			Assert.AreEqual("2", result);
		}
	}

	public class Test2
	{
		public int Key = 0;
		public string Name;
	}

	public class Test1
	{
		public string FirstName { get; set; }
		public string Id { get; set; }
		public string LastName { get; set; }
	}
}