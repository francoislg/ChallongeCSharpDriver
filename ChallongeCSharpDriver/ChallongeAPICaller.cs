
namespace ChallongeCSharpDriver {
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;

    public class ChallongeAPICaller {
        private ChallongeConfig config;
        private class GetAllTournamentRequest {
            public string api_key { get; set; }
        };
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
                client.BaseAddress = new Uri(config.httpAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // HTTP GET
                HttpResponseMessage response = await client.GetAsync(getAPIString("tournaments") + "?api_key=" + config.apiKey);
                if (response.IsSuccessStatusCode) {
                    Tournaments tournaments = await response.Content.ReadAsAsync<Tournaments>();
                    Console.WriteLine("{0}", tournaments.tournaments);
                } else {
                    Console.WriteLine("{0}", response);
                }
            }
        }

        private string getAPIString(string api) {
            return api + "." + config.responseType;
        }

        private string getResponseType(){
            switch (config.responseType) {
                case ChallongeConfig.ResponseType.JSON:
                    return "JSON";
                case ChallongeConfig.ResponseType.XML:
                    return "XML";
                default:
                    return "JSON";
            }
        }
    }
}
