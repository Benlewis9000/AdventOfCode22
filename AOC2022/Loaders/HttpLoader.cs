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
        Uri uri = new Uri($"{_config.BaseAddress}/{problem.Year}/day/{problem.Day}/input");

        CookieContainer cookieContainer = new CookieContainer();
        cookieContainer.Add(uri, new Cookie("session", _config.SessionId));

        return DoLoadAsync(uri, cookieContainer).Result;
    }


    // ConfigureAwait(false) prevents deadlock when Result is called on returned Task
    // https://blog.stephencleary.com/2012/07/dont-block-on-async-code.html
    private async Task<string> DoLoadAsync(Uri uri, CookieContainer cookieContainer)
    {
        HttpClient client = new HttpClient(new HttpClientHandler { CookieContainer = cookieContainer });
        HttpResponseMessage response = await client.GetAsync(uri).ConfigureAwait(false);
        response.EnsureSuccessStatusCode();
        client.Dispose();

        return await response.Content.ReadAsStringAsync().ConfigureAwait(false);
    }
}