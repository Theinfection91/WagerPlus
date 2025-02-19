﻿using System;
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
        public int MessageValue { get; set; } = 1;
        public TimeSpan MessageCooldown {  get; set; } = TimeSpan.FromSeconds(5);
        public int DailyRewardAmount { get; set; } = 50;

        public CurrencyConfigFile() { }
    }
}
