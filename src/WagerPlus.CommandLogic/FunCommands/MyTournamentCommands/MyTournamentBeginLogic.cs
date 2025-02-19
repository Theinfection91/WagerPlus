using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WagerPlus.Managers;

namespace WagerPlus.CommandLogic.FunCommands.MyTournamentCommands
{
    public class MyTournamentBeginLogic : Logic
    {
        private MyTournamentManager _myTournamentManager;
        public MyTournamentBeginLogic(MyTournamentManager myTournamentManager) : base("MyTournament Begin")
        {
            _myTournamentManager = myTournamentManager;
        }
    }
}
