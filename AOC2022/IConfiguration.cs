namespace Aoc.Core;

internal interface IConfiguration
{
    public string GetAddress();
    public string GetCookie();
    public string GetYear();
    public string GetDay();
    public string GetPart();
}