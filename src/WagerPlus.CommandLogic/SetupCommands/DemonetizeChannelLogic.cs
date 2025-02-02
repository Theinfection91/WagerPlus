using Discord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WagerPlus.Managers;

namespace WagerPlus.CommandLogic.SetupCommands
{
    public class DemonetizeChannelLogic : Logic
    {
        public ConfigManager _configManager;
        public MessageManager _messageManager;
        public DemonetizeChannelLogic(ConfigManager configManager, MessageManager messageManager) : base("Demonetize Channel")
        {
            _configManager = configManager;
            _messageManager = messageManager;
        }

        public Embed DemonetizeChannelProcess(ulong channelId)
        {
            if (!_configManager.IsChannelMonetized(channelId))
            {
                return _messageManager.CreateErrorEmbed($"{Name}", $"{channelId} is not a monetized channel. Add it to the list by using `/setup demonetize_channel`");
            }

            _configManager.RemoveFromMonetizedChannels(channelId);
            return _messageManager.CreateBasicEmbed($"{Name} Success", $"{channelId} has been demonetized and users will no longer earn {_configManager.GetCurrencyName()} for messages in that channel.");
        }
    }
}
