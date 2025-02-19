using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WagerPlus.MyTournament.Models.Staff
{
    public class Promoter : StaffMember
    {
        public Promoter(string name) : base(name)
        {
            Title = "Promoter";
        }
    }
}
