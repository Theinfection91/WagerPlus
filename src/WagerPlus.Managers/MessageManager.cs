using Discord;
using Discord.Interactions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WagerPlus.Core.Enums.PoolEnums;
using WagerPlus.Core.Models.Pools;

namespace WagerPlus.Managers
{
    public class MessageManager
    {
        public MessageManager() { }

        #region General Use Embeds
        public Embed CreateBasicEmbed(string title, string message)
        {
            return new EmbedBuilder()
            .WithTitle(title)
            .WithDescription(message)
            .WithColor(Discord.Color.Green)
            .WithTimestamp(DateTimeOffset.UtcNow)
            .Build();
        }
        public Embed CreateErrorEmbed(string title, string message)
        {
            return new EmbedBuilder()
            .WithTitle($"{title} Error")
            .WithDescription(message)
            .WithColor(Discord.Color.Red)
            .WithTimestamp(DateTimeOffset.UtcNow)
            .Build();
        }
        #endregion

        #region Pool Messages
        
        #endregion
    }
}
