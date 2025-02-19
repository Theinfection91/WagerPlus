using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WagerPlus.MyTournament.Models
{
    public class Bettor : NPC
    {
        public int Wallet { get; set; }
        public Bettor(string name) : base(name)
        {

        }
    }
}
