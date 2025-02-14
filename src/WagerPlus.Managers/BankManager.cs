using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WagerPlus.Managers
{
    public class BankManager : DataDriven
    {
        public BankManager(DataManager dataManager) : base("BankManager", dataManager)
        {

        }
    }
}
