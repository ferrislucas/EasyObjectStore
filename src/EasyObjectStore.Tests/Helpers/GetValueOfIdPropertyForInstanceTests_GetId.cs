using System;
using AutoMoq;
using EasyObjectStore.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

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
		public void Returns_null_when_Id_is_Guid_and_it_is_not_set()
		{
			mocker.GetMock<IGetNameOfIdPropertyForType>()
				.Setup(a => a.GetNameOfIdProperty(It.IsAny<Type>()))
				.Returns("Id");

			var result = mocker.Resolve<GetValueOfIdPropertyForInstance>()
				.GetId(new TestClassWitGuidId());

			Assert.AreEqual(null, result);
		}

		[TestMethod]
		public void Returns_null_when_Id_field_is_null()
		{
			mocker.GetMock<IGetNameOfIdPropertyForType>()
				.Setup(a => a.GetNameOfIdProperty(typeof(Test1)))
				.Returns("Id");

			var result = mocker.Resolve<GetValueOfIdPropertyForInstance>()
				.GetId(new Test1());

			Assert.AreEqual(null, result);
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

	public class TestClassWitGuidId
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
	}

	public class Test3
	{
		public int Bleh { get; set; }
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