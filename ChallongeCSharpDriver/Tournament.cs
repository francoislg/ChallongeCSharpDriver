using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallongeCSharpDriver {
    public sealed class Tournament {
        public int id { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public string description { get; set; }
        public string tournament_type { get; set; }
        public override string ToString(){
            return "Tournament #" + id + ", \"" + name + "\" at https://challonge.com/" + url + " (" + description + ")";
        }
    }
}
