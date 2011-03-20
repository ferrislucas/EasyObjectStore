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
		//[TestMethod]
		public void TestMethod1()
		{
			var easyObjectStore = EasyObjectStoreFactory<SomeClass2>.GetInstance(@"C:\Users\lucasf\Desktop\remove");
			var id = easyObjectStore.SaveAndReturnId(new SomeClass2()
															{
																Name = "thing #1",
															});
		}
	}

	public class SomeClass2
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public SomeThing[] Things { get; set; }
	}

	public class SomeClass
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public SomeThing[] Things { get; set; }
	}

	public class SomeThing
	{
		public string Name { get; set; }
		public int? Quantity { get; set; }
	}
}
