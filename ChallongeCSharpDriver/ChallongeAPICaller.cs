
namespace ChallongeCSharpDriver {
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;

    public class ChallongeAPICaller {
        private ChallongeConfig config;
        private class Tournament {
            public string tournament_type {get; set;}
        }
        private class Tournaments {
            public List<Tournament> tournaments { get; set; }
        }

        public ChallongeAPICaller(ChallongeConfig config) {
            this.config = config;
        }
        
        public async Task GetAllTournaments() {
            using (var client = new HttpClient()) {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // HTTP GET
                HttpResponseMessage response = await client.GetAsync(config.httpAddress + getAPIString("tournaments") + "?api_key=" + config.apiKey);

                if (response.IsSuccessStatusCode) {
                    Tournaments tournaments = await response.Content.ReadAsAsync<Tournaments>();
                    Console.WriteLine(tournaments.tournaments);
                } else {
                    Console.WriteLine(response);
                }
            }
        }

        private string getAPIString(string api) {
            return api + "." + config.getResponseType();
        }
    }
}
