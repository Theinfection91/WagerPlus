using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WagerPlus.MyTournament.Models.Staff;

namespace WagerPlus.MyTournament.Models
{
    public class Tournament
    {
        // Basic Info
        public ulong Id { get; set; } // User's Discord ID
        public int Level { get; set; } = 1;
        public int Experience { get; set; } = 0;

        // Arena
        public Arena Arena { get; set; }

        // Teams
        public int MaxTeams { get; set; } = 6;
        public List<MetaTeam>? CurrentTeams { get; set; } = [];

        // Matches and History
        public List<Match> Matches { get; set; } = [];
        public List<Match> MatchHistory { get; set; } = [];

        // Staff Members
        public Bookkeeper Bookkeeper { get; set; }
        public Promoter Promoter { get; set; }
        public TeamCoordinator TeamCoordinator { get; set; }

        // Active and Timestamp Info
        public bool IsActive { get; set; } = false;
        public DateTime Started { get; set; }
        public DateTime Ended { get; set; }

        public Tournament(ulong discordId)
        {
            Id = discordId;
        }
    }
}
