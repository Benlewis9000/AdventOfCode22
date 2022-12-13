using System.IO;
using System.Text.Json;

namespace Aoc.Core.Loaders;

public class ConfigurationLoader : ILoader<IConfiguration?>
{
    private readonly string _path;
    
    public ConfigurationLoader(string path)
    {
        _path = path;
    }

    public bool TryLoad(out IConfiguration? config)
    {
        config = default;
        ILoader<string?> fileLoader = new FileLoader(_path);
        if (!fileLoader.TryLoad(out string? json))
        {
            return false;
        }
        if (json == null)
        {
            return false;
        }

        var deserializer = new ConfigurationDeserializer(json);
        return deserializer.TryDeserialize(out config);
    }
}