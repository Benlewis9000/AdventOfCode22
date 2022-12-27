using Aoc.Core;
using Aoc.Core.Loaders;

namespace Aoc.Test;

internal class ConfigurationLoaderTests
{
    [Test]
    public void Deserialize_ShouldCreateConfigInstance()
    {
        string json =
            "{\r\n  \"sessionId\": \"id\",\r\n  \"baseAddress\": \"https://adventofcode.com/\"\r\n}";
        var deserializer = new ConfigurationDeserializer(json);
        deserializer.TryDeserialize(out var config);
        DoAssertions(config);
    }

    [Test]
    public void Deserialize_ShouldLoadAndCreateConfigFromFile()
    {
        string path = @"test-config.json";
        var loader = new ConfigurationLoader(path);
        var config = loader.Load();
        DoAssertions(config);
    }

    private void DoAssertions(IConfiguration? config)
    {
        Assert.IsNotNull(config);
        Assert.That(config.SessionId, Is.EqualTo("id"));
    }
}