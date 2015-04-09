
namespace ChallongeCSharpDriver.Main {
    using System;
    using System.Collections.Generic;
    using System.Text;
    using ChallongeCSharpDriver.Caller;
    using ChallongeCSharpDriver.Core.Results;
    using ChallongeCSharpDriver.Core.Queries;
    using System.Threading.Tasks;

    public class Tournaments {
        ChallongeAPICaller caller;

        public Tournaments(ChallongeAPICaller caller) {
            this.caller = caller;
        }

        public async Task<List<TournamentObject>> getTournaments() {
            List<TournamentResult> tournamentResultList = await new TournamentsQuery().call(caller);
            List<TournamentObject> tournamentList = new List<TournamentObject>();
            foreach (TournamentResult result in tournamentResultList) {
                tournamentList.Add(new TournamentObject(result, caller));
            }
            return tournamentList;
        }
    }
}
