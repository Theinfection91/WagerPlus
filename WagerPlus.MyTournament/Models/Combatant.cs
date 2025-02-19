using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WagerPlus.MyTournament.Models
{
    public class Combatant : NPC
    {
        // Stats
        public int Finesse { get; set; }
        public int Composure { get; set; }
        public int Wisdom { get; set; }

        // Misc.
        public string CurrentTeam { get; set; }

        public Combatant(string name) : base(name)
        {

        }
    }
}
