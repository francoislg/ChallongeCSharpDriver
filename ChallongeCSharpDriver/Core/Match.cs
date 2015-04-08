using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallongeCSharpDriver.Core {
    public interface Match {
        MatchState matchState {get; }
        Nullable<int> player1_id { get; }
        Nullable<int> player2_id { get; }
        string ToString();
    }
}
