
namespace ChallongeCSharpDriver {
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;

    public class ChallongeAPICaller {
        private ChallongeConfig config;
        private class TournamentsQueryResult {
            public Tournament tournament { get; set; }
        }

        public ChallongeAPICaller(ChallongeConfig config) {
            this.config = config;
        }
        
        public async Task<Tournaments> GetAllTournaments() {
            using (var client = new HttpClient()) {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // HTTP GET
                HttpResponseMessage response = await client.GetAsync(config.httpAddress + getAPIString("tournaments") + "?api_key=" + config.apiKey);

                if (response.IsSuccessStatusCode) {
                    List<TournamentsQueryResult> tournamentsQueryResult = await response.Content.ReadAsAsync<List<TournamentsQueryResult>>();
                    List<Tournament> tournamentsList = new List<Tournament>();
                    foreach (TournamentsQueryResult queryResult in tournamentsQueryResult) {
                        tournamentsList.Add(queryResult.tournament);
                    }
                    return new Tournaments() { tournaments = tournamentsList };
                } else {
                    Console.WriteLine(response);
                    throw new CouldNotReceiveResponse();
                }
            }
        }

        private string getAPIString(string api) {
            return api + "." + config.getResponseType();
        }
    }
}
