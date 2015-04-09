using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallongeCSharpDriver.Core {
    using System.Net.Http;

    public interface ChallongeAPICaller {
        Task<ReturnType> CallAPI<ReturnType>(string path);
        Task<ReturnType> CallAPI<ReturnType>(string path, Dictionary<string, string> parameters);
    }
}
