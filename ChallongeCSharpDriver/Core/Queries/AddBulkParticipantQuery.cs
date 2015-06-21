using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallongeCSharpDriver.Core.Queries {
    using ChallongeCSharpDriver.Core.Objects;
    using ChallongeCSharpDriver.Core.Results;
    using ChallongeCSharpDriver.Caller;

    public class AddBulkParticipantQuery : ChallongeQuery<bool> {
        public int tournamentID { get; set; }
        public List<ParticipantEntry> entries { get; set; }

        public AddBulkParticipantQuery(int tournamentID, List<ParticipantEntry> entries) {
            this.tournamentID = tournamentID;
            this.entries = entries;
        }

        private ChallongeQueryParameters getParameters() {
            ChallongeQueryParameters parameters = new ChallongeQueryParameters();
            int num = 0;
            entries.ForEach(entry => {
                parameters.Add("participant[][name]", entry.name);
                num++;
            });
            return parameters;
        }

        private string getAPIPath() {
            return "tournaments/" + tournamentID + "/participants/bulk_add";
        }

        public Task<bool> call(ChallongeAPICaller caller) {
            throw new NotSupportedException();
            //return await caller.POST(getAPIPath(), getParameters());
        }
    }
}
