using System.Threading.Tasks;

namespace ChallongeCSharpDriver.Core.Queries {
    using System.Collections.Generic;
    using ChallongeCSharpDriver.Core.Objects;
    using ChallongeCSharpDriver.Core.Results;

    public class AddParticipantQuery : ChallongeQuery<ParticipantResult> {
        public int tournamentID { get; set; }
        public ParticipantEntry entry { get; set; }

        public AddParticipantQuery(int tournamentID, ParticipantEntry entry) {
            this.tournamentID = tournamentID;
            this.entry = entry;
        }

        private class ParticipantQueryResult {
            public ParticipantResult participant { get; set; }
        }

        private Dictionary<string, string> getParameters() {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("participant[name]", entry.name);
            return parameters;
        }

        private string getAPIPath() {
            return "tournaments/" + tournamentID + "/participants";
        }

        public async Task<ParticipantResult> call(ChallongeAPICaller caller) {
            ParticipantQueryResult participantResult = await caller.POST<ParticipantQueryResult>(getAPIPath(), getParameters());
            return participantResult.participant;
        }
    }
}
