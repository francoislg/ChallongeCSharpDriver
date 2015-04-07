using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallongeCSharpDriver.Queries {
    public class TournamentMatchesQuery : ChallongeQuery {
        public int tournamentID { get; set; }
        public Nullable<MatchState> matchState { get; set; }
        public Nullable<int> participantID { get; set; }

        public TournamentMatchesQuery(int tournamentID) {
            this.tournamentID = tournamentID;
        }

        public Dictionary<String, String> getParameters() {
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

        public string getAPIPath() {
            return "tournaments/" + tournamentID + "/matches";
        }
    }
}
