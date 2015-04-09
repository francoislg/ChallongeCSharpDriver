﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallongeCSharpDriver.Main {
    public interface Tournament {
        int remainingMatches { get; }
        Task<OpenMatch> getNextMatch();
        string ToString();
    }
}