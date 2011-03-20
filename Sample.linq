<Query Kind="Program">
  <Reference Relative="src\EasyObjectStore\bin\Debug\EasyObjectStore.dll">C:\_Application\EasyObjectStore\src\EasyObjectStore\bin\Debug\EasyObjectStore.dll</Reference>
  <Namespace>EasyObjectStore</Namespace>
</Query>

void Main()
{
	var easyObjectStore = EasyObjectStoreFactory<SomeClass>.GetInstance(@"C:\Users\lucasf\Desktop\remove");
	var id = easyObjectStore.SaveAndReturnId(new SomeClass()
										{
											Name = "thing #1",
										});
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