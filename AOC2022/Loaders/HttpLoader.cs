using System.Net;

namespace Aoc.Core.Loaders;

public class HttpLoader : ILoader<string>
{
    private readonly IConfiguration _config;
    private readonly IProblem _problem;

    public HttpLoader(IConfiguration config, IProblem problem)
    {
        _config = config;
        _problem = problem;
    }

    public string Load()
    {
        Uri problemInputUri = new Uri($"{_config.BaseAddress}/{_problem.Year}/day/{_problem.Day}/input");

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