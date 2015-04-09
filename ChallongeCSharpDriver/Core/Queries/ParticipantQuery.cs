using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallongeCSharpDriver.Core.Queries {
    using System.Net.Http;
    using ChallongeCSharpDriver.Core.Results;
    using ChallongeCSharpDriver.Caller;

    public class ParticipantQuery : ChallongeQuery<ParticipantResult> {
        public int tournamentID { get; set; }
        public int participantID { get; set; }

        public ParticipantQuery(int tournamentID, int participantID) {
            this.tournamentID = tournamentID;
            this.participantID = participantID;
        }

        private class ParticipantQueryResult {
            public ParticipantResult participant { get; set; }
        }

        private Dictionary<String, String> getParameters() {
            return  new Dictionary<string, string>();
        }

        private string getAPIPath() {
            return "tournaments/" + tournamentID + "/participants/" + participantID;
        }

        public async Task<ParticipantResult> call(ChallongeAPICaller caller) {
            HttpContent content = await caller.CallAPI(getAPIPath(), getParameters());
            ParticipantQueryResult participantResult = await content.ReadAsAsync<ParticipantQueryResult>();
            return participantResult.participant;
        }
    }
}
