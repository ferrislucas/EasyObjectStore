using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EasyObjectStore.Tests
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMethod1()
		{
			var easyObjectStore = EasyObjectStoreFactory<SomeClass>.GetInstance(@"C:\Users\lucasf\Desktop\remove");
			var id = easyObjectStore.SaveAndReturnId(new SomeClass()
			{
				Name = "thing #1",
			});
		}
	}

	[Serializable]
	public class SomeClass
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public SomeThing[] Things { get; set; }
	}

	public class SomeThing
	{
		public string Name { get; set; }
		public int? Quantity { get; set; }
	}
}
