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
        public List<StaffMember> HiringPool { get; private set; }
        public MyTournamentManager(DataManager dataManager, RNGMachine rngMachine) : base("MyTournamentManager", dataManager)
        {
            RNGMachine = rngMachine;
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

        public void GenerateHiringPool(int level)
        {
            if (level < 5)
            {

            }
            if (level >= 5)
            {

            }
        }

        public void AddTournamentToDatabase(Tournament tournament)
        {
            _dataManager.MyTournamentMatrix.Tournaments.Add(tournament);
            _dataManager.SaveAndReloadMyTournamentMatrix();
        }
    }
}
