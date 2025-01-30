using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WagerPlus.Core.Interfaces;

namespace WagerPlus.Core.Models
{
    public class Currency : ICurrency
    {
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public int Total { get; set; }

        public Currency(string name, string abbreviation)
        {
            Name = name;
            Abbreviation = abbreviation;
        }

        public int GetTotalCurrency()
        {
            return Total;
        }

        public void Add(int amount)
        {
            Total += amount;
        }

        public void Subtract(int amount)
        {
            Total -= amount;
            if (Total <= 0)
            {
                Total = 0;
            }
        }

        public void Set(int amount)
        {
            Total = amount;
        }
    }
}
