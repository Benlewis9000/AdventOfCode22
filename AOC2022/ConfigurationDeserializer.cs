using Newtonsoft.Json;
using JsonException = System.Text.Json.JsonException;

namespace Aoc.Core;

public class ConfigurationDeserializer
{
    private readonly string _json;

    public ConfigurationDeserializer(string json)
    {
        _json = json;
    }

    public bool TryDeserialize(out IConfiguration? config)
    {
        config = default;
        try
        {
            config = JsonConvert.DeserializeObject<Configuration>(_json);
            return true;
        }
        catch (JsonException)
        {
            Console.WriteLine($"Failed to deserialize {nameof(Configuration)}:" + Environment.NewLine +
                              $"{_json}");
        }
        return false;
    }
}