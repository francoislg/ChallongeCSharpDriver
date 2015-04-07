
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
                HttpResponseMessage response = await client.GetAsync(getAPIString("tournaments"));

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

        private class MatchesQueryResult {
            public Match match { get; set; }
        }

        public async Task<Matches> GetTournamentMatches(int tournamentID) {
            using (var client = new HttpClient()) {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // HTTP GET
                HttpResponseMessage response = await client.GetAsync(getAPIString("tournaments/" + tournamentID + "/matches"));

                if (response.IsSuccessStatusCode) {
                    List<MatchesQueryResult> matchesQueryResult = await response.Content.ReadAsAsync<List<MatchesQueryResult>>();
                    List<Match> matchesList = new List<Match>();
                    foreach (MatchesQueryResult queryResult in matchesQueryResult) {
                        matchesList.Add(queryResult.match);
                    }
                    return new Matches() { matches = matchesList };
                } else {
                    Console.WriteLine(response);
                    throw new CouldNotReceiveResponse();
                }
            }
        }
        private string getAPIString(string api) {
            return getAPIString(api, new string[] {});
        }

        private string getAPIString(string api, string[] extraParameters) {
            return config.httpAddress + api + "." + config.getResponseType() + "?api_key=" + config.apiKey + "&" + string.Join("&", extraParameters);
        }
    }
}
