using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChallongeCSharpDriverExample {
    using ChallongeCSharpDriver.Caller;
    using ChallongeCSharpDriver;
    using ChallongeCSharpDriver.Main;
    using ChallongeCSharpDriver.Core.Objects;
    using ChallongeCSharpDriver.Core.Queries;
    using System.IO;

    public partial class Example : Form {
        private ChallongeHTTPClientAPICaller caller;
        private Tournaments tournaments;

        public Example() {
            InitializeComponent();
            string configPath = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/challongeCSharpDriver.config";
            var data = readIni(configPath);
            ChallongeConfig config = new ChallongeConfig(data["api_key"]);
            caller = new ChallongeHTTPClientAPICaller(config);
            tournaments = new Tournaments(caller);
        }

        private Dictionary<string, string> readIni(string file) {
            Dictionary<string, string> ini = new Dictionary<string, string>();
            foreach (var row in File.ReadAllLines(file))
                ini.Add(row.Split('=')[0], string.Join("=", row.Split('=').Skip(1).ToArray()));
            return ini;
        }

        private async void sendQueryButton_Click(object sender, EventArgs e) {
            Button me = (Button)sender;
            me.Hide();
            List<StartedTournament> ts = await tournaments.getStartedTournaments();
            ts.ForEach(t => Console.WriteLine(ts));
            /*


            StartedTournament tournament = await tournaments.getTournament(1580436);
            Console.WriteLine(await tournament.remainingUncompletedMatches);
            OpenMatch nextMatch = await tournament.getNextMatch();
            Console.WriteLine(nextMatch);*/
            me.Show();
        }

        private async void button1_Click(object sender, EventArgs e) {
            Button me = (Button)sender;
            me.Hide();
            TournamentCreator creator = new TournamentCreator(caller);
            PendingTournament tournament = await creator.create("TestingCreator", TournamentType.Double_Elimination, "ssbmCPU_1");
            await tournament.AddParticipant("CPU44");
            await tournament.AddParticipant("CPU22");
            StartedTournament started = await tournament.StartTournament();
            Console.WriteLine(await started.remainingUncompletedMatches);
            me.Show();
        }
    }
}
