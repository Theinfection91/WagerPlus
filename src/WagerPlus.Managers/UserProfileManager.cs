using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WagerPlus.Core.Models;

namespace WagerPlus.Managers
{
    public class UserProfileManager : DataDriven
    {
        public UserProfileManager(DataManager dataManager) : base("UserProfileManager", dataManager)
        {

        }

        public void LoadUserProfileList()
        {
            _dataManager.LoadUserProfileList();
        }

        public void SaveUserProfileList()
        {
            _dataManager.SaveUserProfileList(_dataManager.UserProfileList);
        }

        public void SaveAndReloadUserProfileList()
        {
            SaveUserProfileList();
            LoadUserProfileList();
        }

        public bool IsUserRegistered(ulong discordId)
        {
            foreach (UserProfile userProfile  in _dataManager.UserProfileList.Users)
            {
                if (userProfile.DiscordId.Equals(discordId))
                {
                    return true;
                }
            }
            return false;
        }

        public UserProfile? GetUserProfile(ulong discordId)
        {
            foreach (UserProfile userProfile in _dataManager.UserProfileList.Users)
            {
                if (discordId.Equals(userProfile.DiscordId))
                {
                    return userProfile;
                }
            }
            return null;
        }

        public UserProfile? GetUserProfile(string discordName)
        {
            foreach (UserProfile userProfile in _dataManager.UserProfileList.Users)
            {
                if (discordName.Equals(userProfile.DisplayName, StringComparison.OrdinalIgnoreCase))
                {
                    return userProfile;
                }
            }
            return null;
        }

        public void AddToWagerWins(UserProfile userProfile)
        {
            userProfile.WagersWon++;
        }

        public void RegisterNewUserProfile(UserProfile userProfile)
        {
            _dataManager.UserProfileList.Users.Add(userProfile);
            SaveAndReloadUserProfileList();
        }
    }
}
