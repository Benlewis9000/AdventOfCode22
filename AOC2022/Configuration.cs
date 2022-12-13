using Newtonsoft.Json;

namespace Aoc.Core;

public class Configuration : IConfiguration
{
    public string BaseAddress { get; }
    public string SessionId { get; }
    public string InputsPath { get; }
    public IProblem Problem { get; }

    [JsonConstructor]
    public Configuration(string baseAddress, string sessionId, string inputsPath, Problem problem)
    {
        BaseAddress = baseAddress;
        SessionId = sessionId;
        Problem = problem;
        InputsPath = inputsPath;
    }
}