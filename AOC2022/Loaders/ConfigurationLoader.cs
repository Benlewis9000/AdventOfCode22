using System.Text.Json;

namespace Aoc.Core.Loaders;

public class ConfigurationLoader : ILoader<IConfiguration>
{
    private readonly ConfigurationDeserializer _deserializer;
    
    public ConfigurationLoader(string path)
    {
        ILoader<string> fileLoader = new FileLoader(path);
        var json = fileLoader.Load();
        _deserializer = new ConfigurationDeserializer(json);
    }

    public IConfiguration Load()
    {
        return _deserializer.Deserialize();
    }
}