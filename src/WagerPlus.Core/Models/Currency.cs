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
        public int Total { get; set; }

        public Currency() { }

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
