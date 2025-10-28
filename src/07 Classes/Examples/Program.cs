using Examples;

Console.WriteLine("CLASS");
Console.WriteLine();

#region Creating Objects from a Class

MyClass.Run();

#endregion

#region Constructors

MyConstructors.Run();

#endregion

#region Constructor Visibility

MyConstructorVisibility.Run();

#endregion

#region Deconstructor

MyDeconstructor.Run();

#endregion

#region Primary Constructor

MyPrimaryConstructor.Run();

#endregion

#region Finalizer

MyFinalizers.Run();

#endregion

#region Partial Class

Console.WriteLine();
Console.WriteLine("## Partial Class");
Console.WriteLine();

var pc = new PartialClass();
pc.Method1();
pc.Method2();

Console.WriteLine();

#endregion

#region Anonymous Types

MyAnonymous.Run();

#endregion