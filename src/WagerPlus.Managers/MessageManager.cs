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
        public static Embed CreatePoolInfoEmbed(Pool pool)
        {
            var embed = new EmbedBuilder()
                .WithTitle($"📊 Pool Info: {pool.Name}")
                .WithDescription(pool.Description ?? "No description provided.")
                .WithColor(Discord.Color.Blue)
                .AddField("🆔 Pool ID", pool.Id, true)
                .AddField("👤 Owner", $"{pool.OwnerDisplayName} (<@{pool.OwnerDiscordId}>)", true)
                .AddField("📅 Created On", pool.CreatedOn.ToString("g"), true)
                .AddField("🔹 Type", pool.Type.ToString(), true)
                .AddField("📌 Status", pool.Status.ToString(), true)
                .AddField("💰 Total Pot", $"{pool.PotTotal} credits", true)
                .AddField("🎯 Target 1", $"{pool.Targets[1].Name} - Odds: {pool.TargetOneOdds} - Bets: {pool.TargetOneWagerCount} - Pot: {pool.TargetOnePotTotal}", false)
                .AddField("🎯 Target 2", $"{pool.Targets[2].Name} - Odds: {pool.TargetTwoOdds} - Bets: {pool.TargetTwoWagerCount} - Pot: {pool.TargetTwoPotTotal}", false)
                .WithFooter($"🕒 Opened: {pool.Opened:g} | Closed: {pool.Closed:g} | Resolved: {pool.Resolved:g}")
                .WithTimestamp(DateTimeOffset.UtcNow);

            if (pool.IsWinningTargetSet)
            {
                embed.AddField("🏆 Winner", $"{(pool.WinningTarget == PoolTarget.Target_1 ? pool.Targets[1].Name : pool.Targets[2].Name)}", false)
                     .WithColor(Discord.Color.Gold);
            }

            return embed.Build();
        }
        #endregion
    }
}
