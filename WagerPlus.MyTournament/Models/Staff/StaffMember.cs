using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WagerPlus.MyTournament.Enums;

namespace WagerPlus.MyTournament.Models.Staff
{
    public class StaffMember : NPC
    {
        // Title
        public string Title { get; set; }

        // Pay
        public int Salary { get; set; }

        // Skills
        public int Drive { get; set; }
        public int Adaptability { get; set; }
        public int Experience { get; set; }

        // Mood
        public StaffMood Mood { get; set; } = StaffMood.Neutral;

        public StaffMember(string name) : base(name)
        {

        }

        public void CalculateSalary()
        {
            Salary = (Drive + Adaptability + Experience) * 3; 
        }
    }
}
