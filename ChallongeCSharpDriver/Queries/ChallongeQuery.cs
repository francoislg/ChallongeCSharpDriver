using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallongeCSharpDriver.Queries {
    public interface ChallongeQuery {
        Dictionary<String, String> getParameters();
        string getAPIPath();
    }
}
