using static System.Console;

namespace Examples;

internal class MyEnums
{
    public static void Run()
    {
        Enum.GetNames(typeof(Colors)).ToList().ForEach(c => Write($"{c}, "));
        WriteLine();
        
        Enum.GetValues(typeof(Colors)).Cast<int>().ToList().ForEach(v => Write($"{v}, "));
        WriteLine();

        Enum.GetNames<Colors>().ToList().ForEach(c => Write($"{c}, "));
        WriteLine();

        Enum.GetValues<Colors>().ToList().ForEach(v => Write($"{v}, "));
        WriteLine();

        Enum.GetValues<Colors>().Cast<int>().ToList().ForEach(v => Write($"{v}, "));
        WriteLine();

        var enumType = Enum.GetUnderlyingType(typeof(Colors));
        WriteLine($"Underlying type of Colors enum type: {enumType.ToString()}, enum type name: {enumType.FullName}");

        var valuesAsInt = Enum.GetValuesAsUnderlyingType<Colors>();        
        foreach (var i in valuesAsInt)
        {
            WriteLine($"Value as underlying type: {i}, type: {i.GetType().FullName}");
        }


        Enum.TryParse<Colors>("Green", out Colors color);
        WriteLine($"Parsed color: {color}, value: {(int)color}");

        var yellowEnum = Colors.Yellow;

        var yellowName = yellowEnum.ToString();
        WriteLine($"Name of color Yellow: {yellowName}");

        var yellowValue = (int)yellowEnum;
        WriteLine($"Value of color Yellow: {yellowValue}");

        yellowEnum = (Colors)yellowValue;

        yellowName = Enum.GetName<Colors>(yellowEnum);
        WriteLine($"Name of color with value 2: {yellowName}");

        var isDefined = Enum.IsDefined<Colors>(yellowEnum) ? "Defined" : "Not Defined";
        WriteLine($"Is value {yellowValue} defined? {isDefined}");
    }

    public void Examples()
    {
        State s = State.Run;
        switch (s)
        {
            case State.Run: WriteLine("RUN"); break;
            case State.Wait: WriteLine("WAIT"); break;
            case State.Stop: WriteLine("STOP"); break;
            default: WriteLine("UNKNOWN"); break;
        }
        WriteLine();


        MyLongEnum myLongEnum = MyLongEnum.Teacher;
        switch (myLongEnum)
        {
            case MyLongEnum.Admin: WriteLine("ADMIN"); break;
            case MyLongEnum.Teacher: WriteLine("TEACHER"); break;
            case MyLongEnum.Student: WriteLine("STUDENT"); break;
            default: WriteLine("UNKNOWN"); break;
        }
        WriteLine();


        foreach (string color in System.Enum.GetNames(typeof(Colors)))
        {
            WriteLine(color);
        }
        WriteLine();

        foreach (string color in System.Enum.GetValues(typeof(Colors)))
        {
            WriteLine(color);
        }
        WriteLine();

        int i = (int)BorderSide.Left;
        WriteLine($"BorderSide.Left as int: {i}");


        BorderSide side = (BorderSide)i;
        WriteLine($"BorderSide as BorderSide: {side}");


        bool leftOrRight = (int)side <= 2;
        WriteLine($"Is Left or Right? {leftOrRight}");
        WriteLine();


        HorizontalAlignment h1 = (HorizontalAlignment)BorderSide.Right;
        WriteLine($"HorizontalAlignment from BorderSide.Right: {h1}");
        // same as:
        HorizontalAlignment h2 = (HorizontalAlignment)(int)BorderSide.Right;
        WriteLine($"HorizontalAlignment from int of BorderSide.Right: {h2}");
        WriteLine();


        BorderSide borderSide = (BorderSide)12345;
        if (Enum.IsDefined(typeof(BorderSide), borderSide))
            WriteLine("Defined"); // False
        else
            WriteLine("Not Defined"); // True
    }
}

public enum State { Run, Wait, Stop };
public enum MyLongEnum : long { Admin, Teacher, Student };
public enum Colors { Red, Green, Yellow, Orange };
public enum BorderSide { Left = 1, Right, Top = 10, Bottom }
public enum HorizontalAlignment
{
    Left = BorderSide.Left,
    Right = BorderSide.Right,
    Center
}
