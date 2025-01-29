using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WagerPlus.Data.DataModels;

namespace WagerPlus.Data.Handlers
{
    public class CurrencyConfigHandler : DataHandler<CurrencyConfigFile>
    {
        public CurrencyConfigHandler() : base("currency_config.json", "Configs") { }
    }
}
