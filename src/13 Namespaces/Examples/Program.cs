using MyAlias = MyProduct.Component;

Console.WriteLine("NAMESPACE");
Console.WriteLine();

MyProduct.Component.MyClass.Run();
MyAlias.MyClass.x = 42;
Console.WriteLine(MyAlias.MyClass.x);

OtherProduct.MyApp.Run();
YourProduct.Component.YourClass.Run();
