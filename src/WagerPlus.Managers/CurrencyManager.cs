using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WagerPlus.Managers
{
    public class CurrencyManager : DataDriven
    {
        public CurrencyManager(DataManager dataManager) : base("CurrencyManager", dataManager)
        {

        }
    }
}
