using Aoc.Core;
using Aoc.Core.Loaders;

namespace Aoc.Test;

internal class ConfigurationLoaderTests
{
    [Test]
    public void Deserialize_ShouldCreateConfigInstance()
    {
        string json =
            "{\r\n  \"sessionId\": \"id\",\r\n  \"baseAddress\": \"https://adventofcode.com/\",\r\n  \"problem\": {\r\n    \"year\": 2015,\r\n    \"day\": 1,\r\n    \"part\": 1\r\n  }\r\n}";
        var deserializer = new ConfigurationDeserializer(json);
        deserializer.TryDeserialize(out var config);
        DoAssertions(config);
    }

    [Test]
    public void Deserialize_ShouldLoadAndCreateConfigFromFile()
    {
        string path = @"..\..\..\..\Aoc.Test\config.json";
        var loader = new ConfigurationLoader(path);
        loader.TryLoad(out var config);
        DoAssertions(config);
    }

    private void DoAssertions(IConfiguration config)
    {
        Assert.IsNotNull(config);
        Assert.That(config.SessionId, Is.EqualTo("id"));
        Assert.That(config.Problem.Year, Is.EqualTo(2015));
    }
}