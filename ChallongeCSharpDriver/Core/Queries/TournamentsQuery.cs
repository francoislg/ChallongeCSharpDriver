﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallongeCSharpDriver.Core.Queries {
    using ChallongeCSharpDriver.Caller;
    using ChallongeCSharpDriver.Core.Results;
    using ChallongeCSharpDriver.Main;
    using System.Net.Http;

    public class TournamentsQuery : ChallongeQuery<List<TournamentResult>> {
        public Nullable<TournamentType> type { get; set; }
        
        private class TournamentsQueryResult {
            public TournamentResult tournament { get; set; }
        }

        private Dictionary<String, String> getParameters() {
            Dictionary<String, String> parameters = new Dictionary<string, string>();
            if (type.HasValue) {
                switch(type){
                    case TournamentType.Single_Elimination:
                        parameters.Add("type", "single_elimination");
                        break;
                    case TournamentType.Double_Elimination:
                        parameters.Add("type", "double_elimination");
                        break;
                    case TournamentType.Round_Robin:
                        parameters.Add("type", "round_robin");
                        break;
                    case TournamentType.Swiss:
                        parameters.Add("type", "swiss");
                        break;
                }
            }
            return parameters;
        }

        private string getAPIPath() {
            return "tournaments";
        }

        public async Task<List<TournamentResult>> call(ChallongeAPICaller caller) {
            HttpContent content = await caller.CallAPI(getAPIPath(), getParameters());
            List<TournamentsQueryResult> tournamentsQueryResult = await content.ReadAsAsync<List<TournamentsQueryResult>>();
            List<TournamentResult> tournaments = new List<TournamentResult>();
            foreach (TournamentsQueryResult queryResult in tournamentsQueryResult) {
                tournaments.Add(queryResult.tournament);
            }
            return tournaments;
        }
    }
}