
namespace ChallongeCSharpDriver.Caller {
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Net.Http;
    using System.Text.Json;
    using ChallongeCSharpDriver.Core;

    public class ChallongeHTTPClientAPICaller : ChallongeAPICaller {
        private ChallongeConfig config;

        private readonly HttpClient client = new HttpClient();

        public ChallongeHTTPClientAPICaller(ChallongeConfig config) {
            this.config = config;
        }

        public async Task<ReturnType> GET<ReturnType>(string path, Dictionary<string, string> parameters) {
            var stream = client.GetStreamAsync(this.config.url);
            return await JsonSerializer.DeserializeAsync<ReturnType>(await stream);
        }

        public Task<bool> DELETE(string path, Dictionary<string, string> parameters) {
            return PUT(path, parameters);
        }

        public Task<bool> PUT(string path, Dictionary<string, string> parameters) {
            return PUT(path, parameters);
        }

        public Task<ReturnType> PUT<ReturnType>(string path, Dictionary<string, string> parameters) {
            return PUT<ReturnType>(path, parameters);
        }

        public Task<bool> POST(string path, Dictionary<string, string> parameters) {
            return POST(path, parameters);
        }

        public Task<ReturnType> POST<ReturnType>(string path, Dictionary<string, string> parameters) {
            return POST<ReturnType>(path, parameters);
        }

        private
    }
}
