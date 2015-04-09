using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChallongeCSharpDriver.Caller {
    public class ChallongeConfig {
        public enum ResponseType {
            JSON, XML
        }

        public String httpAddress { get; set; }
        public String apiKey { get; set; }
        public ResponseType responseType { get; set; }
        
        public ChallongeConfig(String apiKey) {
            this.apiKey = apiKey;
            this.httpAddress = "https://api.challonge.com/v1/";
            this.responseType = ResponseType.JSON;
        }

        public string getResponseType() {
            switch (responseType) {
                case ChallongeConfig.ResponseType.JSON:
                    return "json";
                case ChallongeConfig.ResponseType.XML:
                    return "xml";
                default:
                    return "json";
            }
        }
    }
}
