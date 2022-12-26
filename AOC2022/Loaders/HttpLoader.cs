using System.Net;

namespace Aoc.Core.Loaders;

public class HttpLoader : ILoader<string>
{
    private readonly IConfiguration _config;

    public HttpLoader(IConfiguration config)
    {
        _config = config;
    }

    public string Load()
    {
        IProblem problem = _config.Problem;
        Uri problemInputUri = new Uri($"{_config.BaseAddress}/{problem.Year}/day/{problem.Day}/input");

        CookieContainer cookieContainer = new CookieContainer();
        cookieContainer.Add(problemInputUri, new Cookie("session", _config.SessionId));

        return DoLoadAsync(problemInputUri, cookieContainer).Result;
    }

    private async Task<string> DoLoadAsync(Uri uri, CookieContainer cookieContainer)
    {
        using HttpClient client = new HttpClient(new HttpClientHandler { CookieContainer = cookieContainer });
        // ConfigureAwait(false) prevents deadlock when Result is called on returned Task
        using HttpResponseMessage response = await client.GetAsync(uri).ConfigureAwait(false);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadAsStringAsync().ConfigureAwait(false);
    }
}