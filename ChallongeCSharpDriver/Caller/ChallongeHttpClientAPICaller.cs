
namespace ChallongeCSharpDriver.Caller {
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    using ChallongeCSharpDriver.Core;

    public class ChallongeHttpClientAPICaller : ChallongeAPICaller {
        private ChallongeConfig config;

        public ChallongeHttpClientAPICaller(ChallongeConfig config) {
            this.config = config;
        }

        public async Task<ReturnType> CallAPI<ReturnType>(string path) {
            return await CallAPI<ReturnType>(path, new Dictionary<string, string>());
        }

        public async Task<ReturnType> CallAPI<ReturnType>(string path, Dictionary<string, string> parameters) {
            using (var client = new HttpClient()) {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // HTTP GET
                HttpResponseMessage response = await client.GetAsync(config.httpAddress + path + "." + config.getResponseType() + "?api_key=" + config.apiKey + dictionaryToString(parameters));

                if (response.IsSuccessStatusCode) {
                    return await response.Content.ReadAsAsync<ReturnType>();
                } else {
                    Console.WriteLine(response);
                    throw new CouldNotReceiveResponse();
                }
            }
        }

        private string dictionaryToString(Dictionary<string, string> dictionary) {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (KeyValuePair<string, string> entry in dictionary) {
                stringBuilder.Append("&" + entry.Key + "=" + entry.Value);
            }
            return stringBuilder.ToString();
        }
    }
}
