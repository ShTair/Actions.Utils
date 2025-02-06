using Microsoft.Extensions.Configuration;

namespace Actions.Utils;

public class OutputParameters(IConfiguration configuration)
{
    private readonly string _gitHubOutput = configuration["GITHUB_OUTPUT"]!;

    public Task Set(string name, string value)
    {
        return File.AppendAllLinesAsync(_gitHubOutput, [$"{name}={value}"]);
    }
}
