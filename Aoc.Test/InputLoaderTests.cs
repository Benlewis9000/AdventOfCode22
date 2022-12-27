using Aoc.Core;
using Aoc.Core.Loaders;

namespace Aoc.Test;

internal class InputLoaderTests
{
    private const string cSessionIdPath = "session.txt";
    private readonly string _sessionId;

    public InputLoaderTests()
    {
        _sessionId = File.ReadAllText(cSessionIdPath);
    }

    [Test]
    public void LoadInput_ShouldLoadInputFromFile()
    {
        var problem = new Problem(2022, 1, 1);
        var config = new Configuration("https://adventofcode.com", 
            $"{_sessionId}",
            "inputs");

        var inputLoader = new InputLoader(config, problem);
        var data = inputLoader.Load();
        Console.WriteLine(data);

        File.Delete(cSessionIdPath);
    }
}