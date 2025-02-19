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
        public int Order { get; set; }
        public MetaTeam HomeTeam { get; set; }
        public MetaTeam AwayTeam { get; set; }
        public List<MetaWager> Wagers { get; set; }



        public Match(int orderNumber, MetaTeam homeTeam, MetaTeam awayTeam)
        {
            Id = Guid.NewGuid();
            Order = orderNumber;
            HomeTeam = homeTeam;
            AwayTeam = awayTeam;
            Wagers = [];
        }
    }
}
