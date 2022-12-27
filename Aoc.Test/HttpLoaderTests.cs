using Aoc.Core;
using Aoc.Core.Loaders;

namespace Aoc.Test;

internal class HttpLoaderTests
{
    private const string cSessionIdPath = "session.txt";
    private readonly string _sessionId;

    public HttpLoaderTests()
    {
        _sessionId = File.ReadAllText(cSessionIdPath);
    }

    [Test]
    [Explicit]
    public void TryLoad_GivenConfig_ShouldLoadProblemInput()
    {
        string json =
           $"{{\r\n  \"sessionId\": \"{_sessionId}\",\r\n  " +
           "\"baseAddress\": \"https://adventofcode.com\"\r\n}";
        new ConfigurationDeserializer(json).TryDeserialize(out var config);
        var problem = new Problem(2017, 1, 1);
        var loader = new HttpLoader(config, problem);
        var data = loader.Load();
        Console.WriteLine(data);
    }
}