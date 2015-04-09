using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallongeCSharpDriver.Core.Queries {
    using ChallongeCSharpDriver.Core.Results;
    using ChallongeCSharpDriver.Main;

    public class TournamentMatchesQuery : ChallongeQuery<List<MatchResult>> {
        public int tournamentID { get; set; }
        public Nullable<MatchState> matchState { get; set; }
        public Nullable<int> participantID { get; set; }

        private class MatchesQueryResult {
            public MatchResult match { get; set; }
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

        public async Task<List<MatchResult>> call(ChallongeAPICaller caller) {
            List <MatchesQueryResult> matchesQueryResult = await caller.CallAPI<List<MatchesQueryResult>>(getAPIPath(), getParameters());
            List<MatchResult> matches = new List<MatchResult>();
            foreach (MatchesQueryResult queryResult in matchesQueryResult) {
                matches.Add(queryResult.match);
            }
            return matches;
        }
    }
}
