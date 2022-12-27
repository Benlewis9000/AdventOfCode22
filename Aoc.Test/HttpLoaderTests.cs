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
           "\"baseAddress\": \"https://adventofcode.com\",\r\n  \"problem\": {\r\n    \"year\": 2017,\r\n    \"day\": 1,\r\n    \"part\": 1\r\n  }\r\n}";
        new ConfigurationDeserializer(json).TryDeserialize(out var config);
        var loader = new HttpLoader(config);
        var data = loader.Load();
        Console.WriteLine(data);
    }
}