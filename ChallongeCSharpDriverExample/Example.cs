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
    using ChallongeCSharpDriver.Main;
    using System.IO;
    
    public partial class Example : Form {
        private ChallongeAPICaller caller;
        private Tournaments tournaments;

        public Example() {
            InitializeComponent();
            string configPath = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/challongeCSharpDriver.config";
            var data = readIni(configPath);
            ChallongeConfig config = new ChallongeConfig(data["api_key"]);
            caller = new ChallongeAPICaller(config);
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
            List<TournamentObject> tournamentList = await tournaments.getTournaments();
            foreach (TournamentObject tournament in tournamentList) {
                Console.WriteLine(tournament);
            }
            me.Show();
        }
    }
}
