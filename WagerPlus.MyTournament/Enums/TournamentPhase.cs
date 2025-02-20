using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WagerPlus.MyTournament.Enums
{
    public enum TournamentPhase
    {
        Executive, // Move Arenas, Fire/Hire Staff
        Planning, // Generating Combatants, Teams, and the Matches to be Played
        Hype, // Pre-Tournament Phase to allow ticket sales and set wagers
        Active, // Tournament is underway
        End // Tournament has ended, money is handled
    }
}
