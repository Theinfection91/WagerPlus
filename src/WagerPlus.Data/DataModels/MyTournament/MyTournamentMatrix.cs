using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WagerPlus.MyTournament.Models;

namespace WagerPlus.Data.DataModels.MyTournament
{
    public class MyTournamentMatrix
    {
        public List<Tournament> Tournaments { get; set; } = [];

        public MyTournamentMatrix() { }
    }
}
