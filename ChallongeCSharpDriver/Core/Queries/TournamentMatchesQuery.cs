using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallongeCSharpDriver.Core.Queries {
    using ChallongeCSharpDriver.Caller;
    using System.Net.Http;

    public class TournamentMatchesQuery : ChallongeQuery<Matches> {
        public int tournamentID { get; set; }
        public Nullable<MatchState> matchState { get; set; }
        public Nullable<int> participantID { get; set; }

        private class MatchesQueryResult {
            public MatchObject match { get; set; }
        }

        public TournamentMatchesQuery(int tournamentID) {
            this.tournamentID = tournamentID;
        }

        private Dictionary<String, String> getParameters() {
            Dictionary<String, String> parameters = new Dictionary<string, string>();
            switch (matchState) {
                case MatchState.Open:
                    parameters.Add("state", "open");
                    break;
                case MatchState.Pending:
                    parameters.Add("state", "pending");
                    break;
                case MatchState.Complete:
                    parameters.Add("state", "complete");
                    break;
                default:
                    parameters.Add("state", "all");
                    break;
            }
            if (participantID.HasValue) {
                parameters.Add("participant_id", participantID.ToString());
            }
            return parameters;
        }

        private string getAPIPath(){
            return "tournaments/" + tournamentID + "/matches";
        }

        public async Task<Matches> call(ChallongeAPICaller caller) {
            HttpContent content = await caller.CallAPI(getAPIPath(), getParameters());
            List<MatchesQueryResult> matchesQueryResult = await content.ReadAsAsync<List<MatchesQueryResult>>();
            MatchCollection matches = new MatchCollection(tournamentID);
            foreach (MatchesQueryResult queryResult in matchesQueryResult) {
                matches.AddMatch(queryResult.match);
            }
            return matches;
        }
    }
}
