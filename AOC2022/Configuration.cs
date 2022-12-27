using Newtonsoft.Json;

namespace Aoc.Core;

public class Configuration : IConfiguration
{
    public string BaseAddress { get; }
    public string SessionId { get; }
    public string InputsPath { get; }

    [JsonConstructor]
    public Configuration(string baseAddress, string sessionId, string inputsPath)
    {
        BaseAddress = baseAddress;
        SessionId = sessionId;
        InputsPath = inputsPath;
    }
}