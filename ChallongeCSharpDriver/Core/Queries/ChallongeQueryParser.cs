using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallongeCSharpDriver.Core.Queries {
    using ChallongeCSharpDriver.Caller;
    using System.Net.Http;

    public interface ChallongeQuery<ReturnType> {
        Task<ReturnType> call(ChallongeAPICaller caller);
    }
}
