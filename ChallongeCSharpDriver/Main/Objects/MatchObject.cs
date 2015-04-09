using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallongeCSharpDriver.Main.Objects {
    using ChallongeCSharpDriver.Core;
    using ChallongeCSharpDriver.Core.Queries;
    using ChallongeCSharpDriver.Core.Results;

    public class MatchObject : OpenMatch {
        private ChallongeAPICaller caller;
        private MatchResult result;
        private MatchState matchState; 
        public MatchState state {
            get {
                return matchState;
            }
        }

        public MatchObject(MatchResult result, ChallongeAPICaller caller) {
            this.result = result;
            this.caller = caller;
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

        public async Task<Participant> getPlayer1() {
            return await getPlayer(result.player1_id);
        }

        public async Task<Participant> getPlayer2() {
            return await getPlayer(result.player2_id);
        }

        private async Task<Participant> getPlayer(Nullable<int> playerID){
            if (playerID.HasValue) {
                ParticipantResult participantResult = await new ParticipantQuery(result.tournament_id, playerID.Value).call(caller);
                return new ParticipantObject(participantResult);
            } else {
                throw new ParticipantNotAssigned();
            }
        }

        public override string ToString() {
            return "Match #" + result.id + ", " + result.state;
        }
    }
}
