using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WagerPlus.Core.Interfaces
{
    public interface ICurrency
    {
        int GetTotalCurrency();
        void Add(int amount);
        void Subtract (int amount);
        void Set (int amount);
    }
}
