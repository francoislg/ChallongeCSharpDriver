using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallongeCSharpDriver.Core {
    public class MatchCollection : Matches {
        private int tournamentID;
        private List<Match> internMatches;
        public List<Match> matches { 
            get {
                return internMatches;
            }
        }

        public MatchCollection(int tournamentID) {
            this.tournamentID = tournamentID;
            this.internMatches = new List<Match>();
        }

        public void AddMatch(Match match) {
            internMatches.Add(match);
        }
    }
}
