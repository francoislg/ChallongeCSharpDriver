﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallongeCSharpDriver.Core.Queries {
    using ChallongeCSharpDriver.Core;
    using ChallongeCSharpDriver.Core.Results;

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
            TournamentQueryResult tournamentQueryResult = await caller.CallAPI<TournamentQueryResult>(getAPIPath(), getParameters());
            return tournamentQueryResult.tournament;
        }
    }
}
