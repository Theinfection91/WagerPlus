using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WagerPlus.MyTournament.Utilities
{
    public class RNGMachine
    {
        private Random random;
        public RNGMachine()
        {
            random = new();
        }
    }
}
