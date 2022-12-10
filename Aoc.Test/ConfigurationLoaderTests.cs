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
        var configurationLoader = new ConfigurationDeserializer(json);
        IConfiguration config = configurationLoader.Deserialize();
        DoAssertions(config);
    }

    [Test]
    public void Deserialize_ShouldLoadAndCreateConfigFromFile()
    {
        string path = @"..\..\..\..\Aoc.Test\config.json";
        var loader = new ConfigurationLoader(path);
        var config = loader.Load();
        DoAssertions(config);
    }

    private void DoAssertions(IConfiguration config)
    {
        Assert.IsNotNull(config);
        Assert.That(config.SessionId, Is.EqualTo("id"));
        Assert.That(config.Problem.Year, Is.EqualTo(2015));
    }
}