using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WagerPlus.Core.Models
{
    public class Currency
    {
        public required string Name { get; set; }
        public required string Abbreviation { get; set; }
        public int CirculationAmount { get; set; }

        public Currency(string name, string abbreviation)
        {
            Name = name;
            Abbreviation = abbreviation;
        }
    }
}
