using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WagerPlus.MyTournament.Models
{
    public class Match
    {
        public Guid Id { get; set; }

        public MetaTeam HomeTeam { get; set; }
        public MetaTeam AwayTeam { get; set; }

        public List<MetaWager> Wagers { get; set; }
        public int BestOf { get; set; }

        public Match(MetaTeam homeTeam, MetaTeam awayTeam, int bestOf)
        {
            HomeTeam = homeTeam;
            AwayTeam = awayTeam;
            BestOf = bestOf;
            Wagers = [];
        }
    }
}
