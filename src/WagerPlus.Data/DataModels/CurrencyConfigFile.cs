using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WagerPlus.Data.DataModels
{
    public class CurrencyConfigFile
    {
        public string CurrencyName { get; set; } = "";
        public string CurrencyAbbreviation { get; set; } = "";
        public bool IsCurrencySetupComplete { get; set; } = false;
        public List<ulong> MonetizedChannels { get; set; } = [];

        public CurrencyConfigFile() { }
    }
}
