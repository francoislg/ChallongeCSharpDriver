using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallongeCSharpDriver.Core {
    using ChallongeCSharpDriver.Caller;
    using System.Net.Http;

    public interface ChallongeAPICaller {
        Task<ReturnType> GET<ReturnType>(string path, Dictionary<string, string> parameters);
        Task<bool> DELETE(string path, Dictionary<string, string> parameters);
        Task<bool> POST(string path, Dictionary<string, string> parameters);
        Task<ReturnType> POST<ReturnType>(string path, Dictionary<string, string> parameters);
        Task<bool> PUT(string path, Dictionary<string, string> parameters);
        Task<ReturnType> PUT<ReturnType>(string path, Dictionary<string, string> parameters);
    }
}
