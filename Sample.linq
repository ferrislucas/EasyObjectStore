<Query Kind="Program">
  <Reference Relative="src\EasyObjectStore\bin\Debug\EasyObjectStore.dll">C:\_Application\EasyObjectStore\src\EasyObjectStore\bin\Debug\EasyObjectStore.dll</Reference>
  <Namespace>EasyObjectStore</Namespace>
</Query>

void Main()
{
	var easyObjectStore = EasyObjectStoreFactory<SomeClass>.GetInstance(@"C:\Users\lucasf\Desktop\remove");
	
//	for (var n = 0; n <= 9999; n++)
//	{
//		easyObjectStore.SaveAndReturnId(new SomeClass()
//													{
//														Name = "thing #" + n,
//													});
//	}
	
	var result = easyObjectStore.GetAll().Where(a => a.Name == "thing #1234").FirstOrDefault();
	result.Dump();
}

public class SomeClass
{
	public string Id {get; set;}
	public string Name {get; set;}
	public SomeThing[] Things {get; set;}
}

public class SomeThing
{
	public string Name {get; set;}
	public int? Quantity {get; set;}
}