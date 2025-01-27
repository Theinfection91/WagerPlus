using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WagerPlus.Data.Handlers;

namespace WagerPlus.Managers
{
    public class ConfigManager
    {
        private DiscordConfigHandler _discordConfigHandler;
        public ConfigManager(DiscordConfigHandler discordConfigHandler)
        {
            _discordConfigHandler = discordConfigHandler;
        }
    }
}
