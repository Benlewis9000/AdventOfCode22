namespace Aoc.Core;

public interface IConfiguration
{
    public string BaseAddress { get; }
    public string SessionId { get; }
    public string InputsPath { get; }
}