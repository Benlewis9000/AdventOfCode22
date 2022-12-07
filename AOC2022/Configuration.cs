namespace Aoc.Core;

internal class Configuration
{
    public string BaseAddress { get; }
    public string SessionId { get; }
    public Problem Problem { get; }

    private Configuration(string baseAddress, string sessionId, Problem problem)
    {
        BaseAddress = baseAddress;
        SessionId = sessionId;
        Problem = problem;
    }
}