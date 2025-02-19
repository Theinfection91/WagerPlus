using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WagerPlus.MyTournament.Models
{
    public class MetaTeam
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Size { get; set; }
        public List<Combatant> Members { get; set; }

        public MetaTeam(string name, int size)
        {
            Id = Guid.NewGuid();
            Name = name;
            Size = size;
            Members = [];
        }
    }
}
