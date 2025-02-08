using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WagerPlus.Core.Models
{
    public class Wallet
    {
        public string DiscordId {  get; set; }
        public List<Currency> Currencies { get; set; }

        public Wallet(string discordId)
        {
            DiscordId = discordId;
            Currencies = [];
        }
    }
}
