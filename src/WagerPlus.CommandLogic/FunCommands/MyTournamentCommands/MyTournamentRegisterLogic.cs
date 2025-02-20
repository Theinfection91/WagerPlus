using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WagerPlus.Managers;

namespace WagerPlus.CommandLogic.FunCommands.MyTournamentCommands
{
    public class MyTournamentRegisterLogic : Logic
    {
        private MyTournamentManager _myTournamentManager;
        public MyTournamentRegisterLogic(MyTournamentManager myTournamentManager) : base("MyTournament Begin")
        {
            _myTournamentManager = myTournamentManager;
        }
    }
}
