using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallongeCSharpDriver.Core {
    public class TournamentCollection : Tournaments {
        private List<Tournament> internTournaments;
        public List<Tournament> tournaments { 
            get {
                return internTournaments;
            }
        }

        public TournamentCollection() {
            this.internTournaments = new List<Tournament>();
        }

        public void AddTournament(Tournament tournament) {
            internTournaments.Add(tournament);
        }
    }
}
