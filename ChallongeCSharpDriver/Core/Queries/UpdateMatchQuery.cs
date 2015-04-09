using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallongeCSharpDriver.Core.Queries {
    using ChallongeCSharpDriver.Core.Results;

    public class UpdateMatchQuery : ChallongeQuery<MatchResult> {
        public int tournamentID { get; set; }
        public int matchID { get; set; }
        public List<Score> scores { get; set; }
        public bool isATie { get; set; }
        public Nullable<int> winnerID { get; set; }
        public Nullable<int> player1_votes { get; set; }
        public Nullable<int> player2_votes { get; set; }

        private class MatchQueryResult {
            public MatchResult match { get; set; }
        }

        public UpdateMatchQuery(int tournamentID, int matchID) {
            this.tournamentID = tournamentID;
            this.matchID = matchID;
            this.scores = new List<Score>();
        }

        private QueryParameters getParameters() {
            QueryParameters parameters = new QueryParameters();
            if (scores.Count > 0) {
                List<string> formattedScoreList = new List<string>();
                foreach (Score score in scores) {
                    formattedScoreList.Add(scoreToString(score));
                }
                parameters.Add("match[scores_csv]", String.Join(",", formattedScoreList));
            }
            if (isATie) {
                parameters.Add("match[winner_id]", "tie");
            } else if (winnerID.HasValue) {
                parameters.Add("match[winner_id]", winnerID.Value.ToString());
            }
            return parameters;
        }

        private string scoreToString(Score score) {
            return score.player1 + "-" + score.player2;
        }

        private string getAPIPath() {
            return "tournaments/" + tournamentID + "/matches/" + matchID;
        }

        public async Task<MatchResult> call(ChallongeAPICaller caller) {
            MatchQueryResult matchQueryResult = await caller.SendToAPI<MatchQueryResult>(getAPIPath(), getParameters());
            return matchQueryResult.match;
        }

    }
}
