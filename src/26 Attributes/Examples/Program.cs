using Examples;

Console.WriteLine("ATTRIBUTES");
Console.WriteLine();

AttributeHelper.PrintAttribute<TaskDescriptorAttribute>(typeof(MyTasks), nameof(MyTasks.ScheduleMeeting));

var myTasksAttrList = AttributeHelper.GetAttributesOfMethods(typeof(MyTasks));
var yourTasksAttrList = AttributeHelper.GetAttributesOfMethods(typeof(YourTasks));

Console.WriteLine();