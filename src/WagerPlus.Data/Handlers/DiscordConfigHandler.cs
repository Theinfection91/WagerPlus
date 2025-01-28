using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WagerPlus.Data.DataModels;

namespace WagerPlus.Data.Handlers
{
    public class DiscordConfigHandler : DataHandler<DiscordConfigFile>
    {
        public DiscordConfigHandler() : base("discord_config.json", "Configs") { }
    }
}
