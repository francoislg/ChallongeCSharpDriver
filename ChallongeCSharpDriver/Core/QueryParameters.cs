using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallongeCSharpDriver.Core {
    public class QueryParameters {
        private List<KeyValuePair<string, string>> internalParameters = new List<KeyValuePair<string, string>>();
        public List<KeyValuePair<string, string>> parameters {
            get {
                return internalParameters;
            }
        }
        public bool hasParameters {
            get {
                return internalParameters.Count > 0;
            }
        }
        public void Add(string key, string value) {
            parameters.Add(new KeyValuePair<string, string>(key, value));
        }

        public override string ToString() {
            List<string> list = new List<string>();
            foreach (KeyValuePair<string, string> entry in parameters) {
                list.Add(entry.Key + "=" + entry.Value);
            }
            return "?" + String.Join("&", list);
        }
    }
}
