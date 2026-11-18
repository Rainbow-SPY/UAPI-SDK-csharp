namespace UAPI.v2.lib;

public interface ILogs
{
    public static void IOutput(string message, string? Type, string OutType)
    {
        const ConsoleColor color = ConsoleColor.DarkYellow;
        Console.ForegroundColor = color;

        Console.Write(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:zz") + " ");
        Console.ForegroundColor = OutType switch
        {
            "Warning" => ConsoleColor.Yellow,
            "Error" => ConsoleColor.Red,
            _ => color
        };
        if (Type is not null)
            Console.Write($"{Type}: ");

        Console.Write(message + "\r\n");
    }

    public static void Info(string message, string? Type = null)
        => IOutput(message, Type, "Info");

    public static void Warning(string message, string? Type = null)
        => IOutput(message, Type, "Warning");

    public static void Error(string message, string? Type = null)
        => IOutput(message, Type, "Error");
}