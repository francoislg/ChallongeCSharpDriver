using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallongeCSharpDriver.Main {
    public interface OpenMatch {
        MatchState state { get; }
        Task<Participant> getPlayer1();
        Task<Participant> getPlayer2();
    }
}
