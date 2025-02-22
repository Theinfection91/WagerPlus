using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WagerPlus.MyTournament.Enums;
using WagerPlus.MyTournament.Models.Arenas;
using WagerPlus.MyTournament.Models.Staff;

namespace WagerPlus.MyTournament.Models
{
    public class Tournament
    {
        // Basic Info
        public ulong Id { get; set; } // User's Discord ID
        public int Level { get; set; } = 1;
        public int Experience { get; set; } = 0;
        public int Reputation { get; set; } = 0;

        // Funds
        public int Bankroll { get; set; } = 3000;

        // Arena
        public Arena Arena { get; set; }

        // Teams
        public int MaxTeams { get; set; } = 8;
        public List<MetaTeam>? CurrentTeams { get; set; } = [];

        // Matches and History
        public List<Match> Matches { get; set; } = [];
        public List<Match> MatchHistory { get; set; } = [];

        // Staff Members
        public Bookkeeper Bookkeeper { get; set; }
        public Promoter Promoter { get; set; }
        public TeamCoordinator TeamCoordinator { get; set; }
        public List<StaffMember> HiringPool { get; set; }

        // Trackers
        public bool HasUsedReroll { get; set; }
        public bool HasHandledBookkeeper { get; set; }
        public bool HasHandledPromoter { get; set; }
        public bool HasHandledTeamCoordinator { get; set; }

        // Phase and Timestamp Info
        public TournamentPhase Phase { get; set; }
        public DateTime TimeStarted { get; set; }
        public DateTime TimeEnded { get; set; }

        // Misc.
        public int Completed { get; set; }

        public Tournament(ulong discordId)
        {
            Id = discordId;
            Arena = new TheKillingFields();
            Phase = TournamentPhase.Executive;
        }

        public void EmployStaffMember(StaffMember newStaffMember)
        {
            if (newStaffMember is Bookkeeper)
            {
                Bookkeeper = (Bookkeeper)newStaffMember;
            }
            if (newStaffMember is Promoter)
            {
                Promoter = (Promoter)newStaffMember;
            }
            if (newStaffMember is  TeamCoordinator)
            {
                TeamCoordinator = (TeamCoordinator)newStaffMember;
            }
        }

        public void ResetExecutiveHandles()
        {
            HasHandledBookkeeper = false;
            HasHandledPromoter = false;
            HasHandledTeamCoordinator = false;
        }
    }
}
