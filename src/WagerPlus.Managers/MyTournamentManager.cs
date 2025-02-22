using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WagerPlus.MyTournament.Models;
using WagerPlus.MyTournament.Models.Staff;
using WagerPlus.MyTournament.Utilities;

namespace WagerPlus.Managers
{
    public class MyTournamentManager : DataDriven
    {
        public RNGMachine RNGMachine { get; set; }
        public MyTournamentManager(DataManager dataManager, RNGMachine rngMachine) : base("MyTournamentManager", dataManager)
        {
            RNGMachine = rngMachine;
        }

        public Tournament? GetUserTournament(ulong discordId)
        {
            foreach (Tournament tournament in _dataManager.MyTournamentMatrix.Tournaments)
            {
                if (tournament.Id.Equals(discordId))
                {
                    return tournament;
                }
            }
            return null;
        }

        public bool IsUserRegistered(ulong discordId)
        {
            foreach (Tournament tournament in _dataManager.MyTournamentMatrix.Tournaments)
            {
                if (tournament.Id.Equals(discordId))
                {
                    return true;
                }
            }
            return false;
        }

        public List<StaffMember> GenerateHiringPool(int level)
        {
            List<StaffMember> candidates = [];
            if (level < 5)
            {
                candidates.Add(RNGMachine.GenerateRandomBookkeeper(false));
                candidates.Add(RNGMachine.GenerateRandomBookkeeper(false));
                candidates.Add(RNGMachine.GenerateRandomPromoter(false));
                candidates.Add(RNGMachine.GenerateRandomPromoter(false));
                candidates.Add(RNGMachine.GenerateRandomTeamCoordinator(false));
                candidates.Add(RNGMachine.GenerateRandomTeamCoordinator(false));
                return candidates;
            }
            if (level >= 5)
            {
                candidates.Add(RNGMachine.GenerateRandomBookkeeper(true));
                candidates.Add(RNGMachine.GenerateRandomBookkeeper(true));
                candidates.Add(RNGMachine.GenerateRandomPromoter(true));
                candidates.Add(RNGMachine.GenerateRandomPromoter(true));
                candidates.Add(RNGMachine.GenerateRandomTeamCoordinator(true));
                candidates.Add(RNGMachine.GenerateRandomTeamCoordinator(true));
                return candidates;
            }
            return candidates;
        }

        public void AddTournamentToDatabase(Tournament tournament)
        {
            _dataManager.MyTournamentMatrix.Tournaments.Add(tournament);
            _dataManager.SaveAndReloadMyTournamentMatrix();
        }
    }
}
