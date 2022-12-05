// See https://aka.ms/new-console-template for more information

using System.Net;

Console.WriteLine("Hello, World!");

Uri address = new Uri("https://adventofcode.com/2022/day/1/input");
CookieContainer cookieContainer = new CookieContainer();
cookieContainer.Add(address, new Cookie("session", "value_here"));

HttpClient client = new HttpClient(new HttpClientHandler {CookieContainer = cookieContainer});
HttpResponseMessage response = await client.GetAsync(address);
response.EnsureSuccessStatusCode();
string responseBody = await response.Content.ReadAsStringAsync();
Console.WriteLine(responseBody);