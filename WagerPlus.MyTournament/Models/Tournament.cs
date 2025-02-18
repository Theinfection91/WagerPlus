using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WagerPlus.MyTournament.Models
{
    public class Tournament
    {
        public string Id { get; set; }
        public int MaxTeams { get; set; }
        public List<MetaTeam>? Teams { get; set; }
    }
}
