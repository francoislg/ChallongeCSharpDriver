
namespace ChallongeCSharpDriver {
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    using ChallongeCSharpDriver.Queries;

    public class ChallongeAPICaller {
        private ChallongeConfig config;

        public ChallongeAPICaller(ChallongeConfig config) {
            this.config = config;
        }

        public async Task<HttpContent> CallAPI(string path) {
            return await CallAPI(path, new Dictionary<string, string>());
        }

        public async Task<HttpContent> CallAPI(string path, Dictionary<string, string> parameters) {
            using (var client = new HttpClient()) {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // HTTP GET
                HttpResponseMessage response = await client.GetAsync(config.httpAddress + path + "." + config.getResponseType() + "?api_key=" + config.apiKey + dictionaryToString(parameters));

                if (response.IsSuccessStatusCode) {
                    return response.Content;
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
