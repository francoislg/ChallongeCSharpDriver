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
        public void Add(string key, string value) {
            parameters.Add(new KeyValuePair<string, string>(key, value));
        }

        public override string ToString() {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (KeyValuePair<string, string> entry in parameters) {
                stringBuilder.Append("&" + entry.Key + "=" + entry.Value);
            }
            return stringBuilder.ToString();
        }
    }
}
