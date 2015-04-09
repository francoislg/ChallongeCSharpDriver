using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallongeCSharpDriver.Main {
    using ChallongeCSharpDriver.Core.Results;

    public class MatchObject : OpenMatch {
        private MatchResult result;
        private MatchState matchState; 
        public MatchState state {
            get {
                return matchState;
            }
        }

        public MatchObject(MatchResult result) {
            this.result = result;
            switch (result.state) {
                case "open":
                    matchState = MatchState.Open;
                    break;
                case "pending":
                    matchState = MatchState.Pending;
                    break;
                case "completed":
                    matchState = MatchState.Complete;
                    break;
                default:
                    throw new InvalidMatchState();
            }
        }

        public string getPlayer1Name() {
            return result.player1_id.ToString();
        }

        public string getPlayer2Name() {
            return result.player2_id.ToString();
        }

        public override string ToString() {
            return "Match #" + result.id + ", " + result.state;
        }
    }
}
