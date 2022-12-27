using Newtonsoft.Json;

namespace Aoc.Core.Loaders;

public class ConfigurationLoader : ILoader<IConfiguration>
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

    public IConfiguration Load()
    {
        if (!File.Exists(_path))
        {
            throw new FileNotFoundException($"Could not find file configuration file at \"{_path}\".");
        }
        string json = File.ReadAllText(_path);
        return JsonConvert.DeserializeObject<Configuration>(json) ??
               throw new InvalidOperationException(
                   $"Failed to deserialize json to {nameof(Configuration)}:{Environment.NewLine}\"{json}\"");
    }
}