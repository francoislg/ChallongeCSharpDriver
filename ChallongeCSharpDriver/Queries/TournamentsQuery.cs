using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallongeCSharpDriver.Queries {
    public class TournamentsQuery : ChallongeQuery {
        public Nullable<TournamentType> type { get; set; }

        public Dictionary<String, String> getParameters() {
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

        public string getAPIPath() {
            return "tournaments";
        }
    }
}
