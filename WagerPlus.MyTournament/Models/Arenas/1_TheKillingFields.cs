using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WagerPlus.MyTournament.Enums;

namespace WagerPlus.MyTournament.Models.Arenas
{
    public class TheKillingFields : Arena
    {
        public TheKillingFields() : base("A001", "The Killing Fields", ArenaQuality.Tier1, 1, 3, 1000, 10, 0, 500)
        {

        }

        public void LevelUp()
        {
            if (Level.Equals(MaxLevel))
                return;

            Level++;

            switch (Level)
            {
                case 2:
                    Capacity = 2000;
                    AdmissionFee = 15;
                    MarketValue = 250;
                    break;

                case 3:
                    Capacity = 3000;
                    AdmissionFee = 20;
                    MarketValue = 500;
                    break;
            }
        }
    }
}
