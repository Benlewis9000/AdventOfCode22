using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AOC2022
{
    internal class InputFetcher : IFetcher
    {
        private readonly string _baseAddress;
        private readonly string _sessionId;
        public Problem Problem { get; }

        /*
         * Should constructor be called only by some factory that holds the config, so as to not need to access or pass the config around
         * to places it does not need to be?
         */
        public InputFetcher(Problem problem, string baseAddress, string sessionId)
        {
            _baseAddress = baseAddress;
            _sessionId = sessionId;
            Problem = problem;
        }

        public async Task<string> Fetch()
        {
            // TODO check to see if input for given config (ie problem) is stored locally

            /*
             * Should components of uri come from a Configuration or Problem?
             * Sounds better to Fetch input for a Problem
             * But config has all the data already
             * H: config also not validated
             * :. maybe best to load config, load problem, and that problem is passed into a InputFetcher, alongside the base addr (but not config!)
             */
            
            Uri address = new Uri($"{_baseAddress}/{Problem.Year}/{Problem.Day}/{Problem.Part}/input");

            CookieContainer cookieContainer = new CookieContainer();
            cookieContainer.Add(address, new Cookie("session", _sessionId));

            HttpClient client = new HttpClient(new HttpClientHandler { CookieContainer = cookieContainer });
            HttpResponseMessage response = await client.GetAsync(address);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }
    }
}
