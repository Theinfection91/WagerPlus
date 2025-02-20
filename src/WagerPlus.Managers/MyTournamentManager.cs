using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WagerPlus.MyTournament.Models;

namespace WagerPlus.Managers
{
    public class MyTournamentManager : DataDriven
    {
        public MyTournamentManager(DataManager dataManager) : base("MyTournamentManager", dataManager)
        {

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

        public void AddTournamentToDatabase(Tournament tournament)
        {
            _dataManager.MyTournamentMatrix.Tournaments.Add(tournament);
            _dataManager.SaveAndReloadMyTournamentMatrix();
        }
    }
}
