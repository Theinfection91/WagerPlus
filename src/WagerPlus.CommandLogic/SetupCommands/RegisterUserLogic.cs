using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Interactions;
using WagerPlus.Core.Models;
using WagerPlus.Managers;

namespace WagerPlus.CommandLogic.SetupCommands
{
    public class RegisterUserLogic : Logic
    {
        private ConfigManager _configManager;
        private UserProfileManager _userProfileManager;
        public RegisterUserLogic(ConfigManager configManager, UserProfileManager userProfileManager) : base("Register User")
        {
            _configManager = configManager;
            _userProfileManager = userProfileManager;
        }

        public string RegisterUserProcess(SocketInteractionContext context)
        {
            // Check if user is registered already
            if (_userProfileManager.IsUserRegistered(context.User.Id))
                return $"The given discord ID is already registered in the database: {context.User.Id} - {context.User.Username}";

            // TODO: Decide on new user currency amount
            UserProfile userProfile = new(context.User.Username, context.User.Id)
            {
                Currency = new()
                {
                    Total = 50
                }
            };
            _userProfileManager.RegisterNewUserProfile(userProfile);

            return $"New User Profile has been registered to - {context.User.Username} ({context.User.Username})";
        }
    }
}
