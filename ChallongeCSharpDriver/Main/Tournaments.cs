
namespace ChallongeCSharpDriver.Main {
    using System;
    using System.Collections.Generic;
    using System.Text;
    using ChallongeCSharpDriver.Core;
    using ChallongeCSharpDriver.Core.Results;
    using ChallongeCSharpDriver.Core.Queries;
    using System.Threading.Tasks;
    using ChallongeCSharpDriver.Main.Objects;

    public class Tournaments {
        ChallongeAPICaller caller;

        public Tournaments(ChallongeAPICaller caller) {
            this.caller = caller;
        }

        public async Task<List<StartedTournament>> getStartedTournaments() {
            List<TournamentResult> tournamentResultList = await new TournamentsQuery() {
                state = TournamentState.InProgress
            }
            .call(caller);
            List<StartedTournament> tournamentList = new List<StartedTournament>();
            foreach (TournamentResult result in tournamentResultList) {
                tournamentList.Add(new TournamentObject(result, caller));
            }
            return tournamentList;
        }

        public async Task<TournamentObject> getTournament(int tournamentID) {
            TournamentResult tournamentResult = await new TournamentQuery(tournamentID).call(caller);
            return new TournamentObject(tournamentResult, caller);
        }
    }
}
