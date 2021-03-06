﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using AutoMoq;
using EasyObjectStore.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace EasyObjectStore.Tests.Helpers
{
	[TestClass]
	public class SetValueOfIdPropertyTests_SetId
	{
		private AutoMoqer mocker;

		[TestInitialize]
		public void Init()
		{
			mocker = new AutoMoqer();
		}

		[TestMethod]
		public void Sets_value_of_id_property()
		{
			var guid = Guid.NewGuid();
			var instance = new TestClass1();
			mocker.GetMock<IGetNameOfIdPropertyForType>().Setup(a => a.GetNameOfIdProperty(It.IsAny<Type>())).Returns("Id");

			mocker.Resolve<SetValueOfIdProperty>().SetId(instance, guid.ToString());

			Assert.AreEqual(guid.ToString(), instance.Id);
		}

		[TestMethod]
		public void Sets_value_of_id_property_when_Id_is_a_guid()
		{
			var guid = Guid.NewGuid();
			var instance = new TestClass2();
			mocker.GetMock<IGetNameOfIdPropertyForType>().Setup(a => a.GetNameOfIdProperty(It.IsAny<Type>())).Returns("Id");

			mocker.Resolve<SetValueOfIdProperty>().SetId(instance, guid);

			Assert.AreEqual(guid.ToString(), instance.Id.ToString());
		}

		public class TestClass2
		{
			public Guid Id { get; set; }
			public string Name { get; set; }
		}

		public class TestClass1
		{
			public string Id { get; set; }
			public string Name { get; set; }
		}
	}
}
