using Newtonsoft.Json;
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

    public IConfiguration? Load()
    {
        string json = File.ReadAllText(_path);
        return JsonConvert.DeserializeObject<Configuration>(json);
    }
}