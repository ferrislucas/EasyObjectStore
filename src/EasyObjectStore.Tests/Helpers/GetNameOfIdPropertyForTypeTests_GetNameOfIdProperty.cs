using System;
using AutoMoq;
using EasyObjectStore.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EasyObjectStore.Tests.Helpers
{
	[TestClass]
	public class GetNameOfIdPropertyForTypeTests_GetNameOfIdProperty
	{
		private AutoMoqer mocker;

		[TestInitialize]
		public void Init()
		{
			mocker = new AutoMoqer();
		}

		[TestMethod]
		public void Returns_Id_when_there_is_an_Id_field()
		{
			var result = mocker.Resolve<GetNameOfIdPropertyForType>().GetNameOfIdProperty(typeof(ClassX));

			Assert.AreEqual("Id", result);
		}

		[TestMethod]
		public void Returns_Id_when_there_is_an_Id_property()
		{
			var result = mocker.Resolve<GetNameOfIdPropertyForType>().GetNameOfIdProperty(typeof(ClassW));

			Assert.AreEqual("Id", result);
		}

		[TestMethod]
		public void Returns_Key_when_there_is_a_Key_field()
		{
			var result = mocker.Resolve<GetNameOfIdPropertyForType>().GetNameOfIdProperty(typeof(ClassY));

			Assert.AreEqual("Key", result);
		}

		[TestMethod]
		public void Returns_Key_when_there_is_a_Key_property()
		{
			var result = mocker.Resolve<GetNameOfIdPropertyForType>().GetNameOfIdProperty(typeof(ClassZ));

			Assert.AreEqual("Key", result);
		}

		[TestMethod]
		public void Throws_exception_when_there_is_not_a_clear_property_or_field_to_use_a_unique_identifier()
		{
			try
			{
				mocker.Resolve<GetNameOfIdPropertyForType>().GetNameOfIdProperty(typeof(ClassWithNoClearIdentifierToUse));
			}
			catch (Exception e)
			{
				Assert.AreEqual("EasyObjectStore was not able to determine what property or field to use for class: " + typeof(ClassWithNoClearIdentifierToUse).FullName, e.Message);
				return;
			}

			throw new Exception("An exception explaining there is no id property should have been thrown here");
		}
	}

	public class ClassWithNoClearIdentifierToUse
	{
		public string Bleh { get; set; }
	}

	public class ClassW
	{
		public string Name { get; set; }
		public int Id {get; set;}
	}

	public class ClassZ
	{
		public string Name { get; set; }
		public int Key { get; set; }
	}

	public class ClassY
	{
		public string Name;
		public int Key;
	}

	public class ClassX
	{
		public string Name;
		public string Id;
	}
}
