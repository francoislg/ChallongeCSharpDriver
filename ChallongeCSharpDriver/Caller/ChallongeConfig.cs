using System;
using System.Collections.Generic;

namespace ChallongeCSharpDriver.Caller {
    public class ChallongeConfig {
        public String apiKey { get; private set; }
        public Dictionary<string, string> defaultParameters { get; private set; }

        public String url { get; private set; } = "https://api.challonge.com/v1/";

        public ChallongeConfig(String apiKey) {
            this.apiKey = apiKey;
            
            defaultParameters = new Dictionary<string, string>();
            defaultParameters.Add("api_key", apiKey);
        }
    }
}
