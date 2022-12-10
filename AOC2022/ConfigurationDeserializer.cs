using Newtonsoft.Json;
using JsonException = System.Text.Json.JsonException;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Aoc.Core;

public class ConfigurationDeserializer
{
    private readonly string _json;

    public ConfigurationDeserializer(string json)
    {
        _json = json;
    }

    public IConfiguration Deserialize()
    {
        try
        {
            return JsonConvert.DeserializeObject<Configuration>(_json);
        }
        catch (JsonException)
        {
            Console.WriteLine($"Failed to deserialize {nameof(Configuration)}:" + Environment.NewLine +
                              $"{_json}");
            throw;
        }
    }
}