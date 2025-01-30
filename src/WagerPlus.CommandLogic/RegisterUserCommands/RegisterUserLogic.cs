using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Interactions;
using WagerPlus.Managers;

namespace WagerPlus.CommandLogic.RegisterUserCommands
{
    public class RegisterUserLogic : Logic
    {
        private UserProfileManager _userProfileManager;
        public RegisterUserLogic(UserProfileManager userProfileManager) : base("Register User")
        {
            _userProfileManager = userProfileManager;
        }

        public string RegisterUserProcess(SocketInteractionContext context)
        {
            // Check if user is registered already
            if (!_userProfileManager.IsUserRegistered(context.User.Id))
            {
                _userProfileManager.RegisterNewUserProfile(context.User.Id, context.User.Username);

                return $"New User Profile has been registered to - {context.User.Username} ({context.User.Username})";
            }
            return $"The given discord ID is already registered in the database: {context.User.Id} - {context.User.Username}";
        }
    }
}
