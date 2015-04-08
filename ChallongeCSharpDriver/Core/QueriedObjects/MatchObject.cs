using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChallongeCSharpDriver.Core.QueriedObjects {
    public class MatchObject : Match {
        public int id { get; set; }
        public string identifier { get; set; }
        public Nullable<int> player1_id { get; set; }
        public Nullable<int> player2_id { get; set; }
        private string currentState;
        private MatchState internMatchState;
        public MatchState matchState {
            get {
                return internMatchState;
            }
        }
        public string state {
            get {
                return currentState;   
            } 
            set {
                currentState = value;
                switch (value) {
                    case "open":
                        internMatchState = MatchState.Open;
                        break;
                    case "complete":
                        internMatchState = MatchState.Complete;
                        break;
                    case "pending":
                        internMatchState = MatchState.Pending;
                        break;
                    default:
                        throw new ArgumentException();
                }
            }
        }
        public override string ToString() {
            return "Match #" + id + ", " + currentState;
        }
    }
}
