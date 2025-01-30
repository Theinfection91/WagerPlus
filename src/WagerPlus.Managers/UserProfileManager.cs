﻿using System;
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

        public void RegisterNewUserProfile(ulong discordId, string displayName)
        {
            UserProfile userProfile = new(displayName, discordId);
            _dataManager.UserProfileList.Users.Add(userProfile);
            SaveAndReloadUserProfileList();
        }
    }
}
