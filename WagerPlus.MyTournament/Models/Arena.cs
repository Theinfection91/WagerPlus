using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WagerPlus.MyTournament.Models
{
    public class Arena
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public int Capacity { get; set; }

        public Arena(string id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
