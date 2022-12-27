using Newtonsoft.Json;

namespace Aoc.Core.Loaders;

public class ConfigurationLoader : ILoader<IConfiguration?>
{
    private const string cDefaultPath = @"config.json";
    private readonly string _path;

    public ConfigurationLoader() : this(cDefaultPath)
    {
    }

    public ConfigurationLoader(string path)
    {
        _path = path;
    }

    public IConfiguration? Load()
    {
        string json = File.ReadAllText(_path);
        return JsonConvert.DeserializeObject<Configuration>(json);
    }
}