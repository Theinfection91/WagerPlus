using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WagerPlus.MyTournament.Models.Staff
{
    public class Bookkeeper : StaffMember
    {
        public Bookkeeper(string name) : base(name)
        {
            Title = "Bookkeeper";
        }
    }
}
