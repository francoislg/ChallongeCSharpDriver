using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallongeCSharpDriver.Core.Queries {
    using System.Net.Http;
    using ChallongeCSharpDriver.Core.Results;
    using ChallongeCSharpDriver.Caller;

    public class TournamentQuery : ChallongeQuery<TournamentResult> {
        public int tournamentID { get; set; }

        public TournamentQuery(int tournamentID) {
            this.tournamentID = tournamentID;
        }

        private class TournamentQueryResult {
            public TournamentResult tournament { get; set; }
        }

        private Dictionary<String, String> getParameters() {
            return  new Dictionary<string, string>();
        }

        private string getAPIPath() {
            return "tournaments/" + tournamentID;
        }

        public async Task<TournamentResult> call(ChallongeAPICaller caller) {
            HttpContent content = await caller.CallAPI(getAPIPath(), getParameters());
            TournamentQueryResult tournamentQueryResult = await content.ReadAsAsync<TournamentQueryResult>();
            return tournamentQueryResult.tournament;
        }
    }
}
