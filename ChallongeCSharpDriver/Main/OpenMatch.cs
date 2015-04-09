using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallongeCSharpDriver.Main {
    public interface OpenMatch {
        MatchState state { get; }
        string getPlayer1Name();
        string getPlayer2Name();
        string ToString();
    }
}
