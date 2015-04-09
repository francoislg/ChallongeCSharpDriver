using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallongeCSharpDriver.Main.Objects {
    using ChallongeCSharpDriver.Core;
    using ChallongeCSharpDriver.Core.Queries;
    using ChallongeCSharpDriver.Core.Results;

    public class TournamentObject : StartedTournament {
        private ChallongeAPICaller caller;
        private TournamentResult result;
        public Task<int> remainingUncompletedMatches {
            get {
                return getNumberOfUncompletedMatches();
            }
        }

        public TournamentObject(TournamentResult result, ChallongeAPICaller caller) {
            this.result = result;
            this.caller = caller;
        }

        public override string ToString() {
            return "Tournament #" + result.id + ", \"" + result.name + "\" at https://challonge.com/" + result.url + " (" + result.description + ")";
        }

        public async Task<OpenMatch> getNextMatch() {
            List<MatchResult> matches = await new MatchesQuery(result.id) { matchState = MatchState.Open }.call(caller);
            if (matches.Count >= 0) {
                return new MatchObject(matches[0], caller);
            } else {
                throw new NoNextMatchAvailable();
            }
        }

        private async Task<int> getNumberOfUncompletedMatches() {
            List<MatchResult> matches = await new MatchesQuery(result.id).call(caller);
            return matches.Select(match => match.state != "completed").Count();
        }
    }
}
