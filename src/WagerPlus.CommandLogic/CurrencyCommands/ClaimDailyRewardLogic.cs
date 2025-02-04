using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Interactions;
using WagerPlus.Core.Models;
using WagerPlus.Managers;

namespace WagerPlus.CommandLogic.CurrencyCommands
{
    public class ClaimDailyRewardLogic : Logic
    {
        private ConfigManager _configManager;
        private CurrencyManager _currencyManager;
        private UserProfileManager _userProfileManager;
        public ClaimDailyRewardLogic(ConfigManager configManager, CurrencyManager currencyManager, UserProfileManager userProfileManager) : base("Claim Daily Reward")
        {
            _configManager = configManager;
            _currencyManager = currencyManager;
            _userProfileManager = userProfileManager;
        }

        public string ClaimDailyRewardProcess(SocketInteractionContext context)
        {
            UserProfile? userProfile = _userProfileManager.GetUserProfile(context.User.Id);
            if (!userProfile.CanClaimDailyReward())
            {
                TimeSpan remaining = userProfile.GetDailyRewardCooldown();
                return $"You have already claimed your daily reward today. You have {remaining.Hours:D2}:{remaining.Minutes:D2}:{remaining.Seconds:D2} left.";
            }

            _currencyManager.AddAmountToUserCurrency(userProfile, _configManager.GetDailyRewardAmount());
            userProfile.LastDailyReward = DateTime.Now;
            _userProfileManager.SaveAndReloadUserProfileList();

            return $"You have claimed your daily reward of {_configManager.GetDailyRewardAmount()} {_configManager.GetCurrencyName()}!";
        }
    }
}
