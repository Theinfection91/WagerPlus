using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WagerPlus.Data.DataModels.MyTournament;

namespace WagerPlus.Data.Handlers
{
    public class MyTournamentHandler : DataHandler<MyTournamentMatrix>
    {
        public MyTournamentHandler() : base("my_tournament_matrix.json", "Databases")
        {

        }
    }
}
