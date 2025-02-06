namespace Actions.Utils;

public class Log
{
    // https://docs.github.com/ja/enterprise-cloud@latest/actions/writing-workflows/choosing-what-your-workflow-does/workflow-commands-for-github-actions

    public static IDisposable StartGroup(string title) => new AreaCommand("group", "endgroup", title);

    public static void Debug(string message)
    {
        Console.WriteLine($"::debug::{message}");
    }

    public static void Notice(string message, string? title)
    {
        Console.WriteLine($"::notice title={title}::{message}");
    }

    public static void Warning(string message, string? title)
    {
        Console.WriteLine($"::warning title={title}::{message}");
    }

    public static void Error(string message, string? title)
    {
        Console.WriteLine($"::error title={title}::{message}");
    }

    public static void AddMask(string value)
    {
        Console.WriteLine($"::add-mask::{value}");
    }

    public static IDisposable StartStopCommand()
    {
        var endToken = Guid.NewGuid().ToString();
        return new AreaCommand("stop-commands", endToken, endToken);
    }

    private class AreaCommand : IDisposable
    {
        private readonly string _end;

        public AreaCommand(string start, string end, string title)
        {
            _end = end;
            Console.WriteLine($"::{start}::{title}");
        }

        public void Dispose()
        {
            Console.WriteLine($"::{_end}::");
        }
    }
}
