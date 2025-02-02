using Discord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WagerPlus.Managers;

namespace WagerPlus.CommandLogic.SetupCommands
{
    public class MonetizeChannelLogic : Logic
    {
        public ConfigManager _configManager;
        public MessageManager _messageManager;
        public MonetizeChannelLogic(ConfigManager configManager, MessageManager messageManager) : base("Monetize Channel")
        {
            _configManager = configManager;
            _messageManager = messageManager;
        }

        public Embed MonetizeChannelProcess(ulong channelId)
        {
            if (_configManager.IsChannelMonetized(channelId))
            {
                return _messageManager.CreateErrorEmbed($"{Name}", $"{channelId} is already monetized. You can remove it by using `/setup demonetize_channel`");
            }

            _configManager.AddToMonetizedChannels(channelId);
            return _messageManager.CreateBasicEmbed($"{Name} Success", $"{channelId} has been monetized! Users are able to earn {_configManager.GetMessageValueAmount()} {_configManager.GetCurrencyName()} for a message every {_configManager.GetMessageCooldownAmount()} seconds. The amount and time span can be changed in the `/setup` commands.");
        }
    }
}
