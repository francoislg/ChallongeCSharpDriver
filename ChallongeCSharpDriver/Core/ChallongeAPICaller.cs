using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallongeCSharpDriver.Core {
    using System.Net.Http;

    public interface ChallongeAPICaller {
        Task<ReturnType> GET<ReturnType>(string path, QueryParameters parameters);
        Task<ReturnType> POST<ReturnType>(string path, QueryParameters parameters);
        Task<ReturnType> PUT<ReturnType>(string path, QueryParameters parameters);
    }
}
