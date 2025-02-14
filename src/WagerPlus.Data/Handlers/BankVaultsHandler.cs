using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WagerPlus.Data.DataModels;

namespace WagerPlus.Data.Handlers
{
    public class BankVaultsHandler : DataHandler<BankVaults>
    {
        public BankVaultsHandler() : base("bank_vaults.json", "Databases")
        {

        }
    }
}
