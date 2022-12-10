using Newtonsoft.Json;

namespace Aoc.Core;

public class Configuration : IConfiguration
{
    public string BaseAddress { get; }
    public string SessionId { get; }
    public IProblem Problem { get; }
    
    private Configuration(string baseAddress, string sessionId, IProblem problem)
    {
        BaseAddress = baseAddress;
        SessionId = sessionId;
        Problem = problem;
    }

    [JsonConstructor]
    private Configuration(string baseAddress, string sessionId, Problem problem) 
        : this(baseAddress, sessionId, (IProblem) problem)
    {
    }
}