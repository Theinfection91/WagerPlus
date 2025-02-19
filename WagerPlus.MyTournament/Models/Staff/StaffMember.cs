using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WagerPlus.MyTournament.Models.Staff
{
    public class StaffMember : NPC
    {
        // Title
        public string Title { get; set; }

        // Skills
        public int Drive { get; set; }
        public int Adaptability { get; set; }
        public int Experience { get; set; }

        public StaffMember(string name) : base(name)
        {

        }
    }
}
