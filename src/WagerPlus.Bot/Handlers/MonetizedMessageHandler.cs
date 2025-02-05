using System.Collections.Concurrent;
using Discord.WebSocket;
using WagerPlus.Managers;

namespace WagerPlus.Bot.Handlers
{
    public class MonetizedMessageHandler
    {
        private readonly ConfigManager _configManager;
        private readonly CurrencyManager _currencyManager;
        private readonly UserProfileManager _userProfileManager;
        private readonly ConcurrentDictionary<ulong, DateTime> _cooldownTracker;

        public MonetizedMessageHandler(ConfigManager configManager, CurrencyManager currencyManager, UserProfileManager userProfileManager)
        {
            _configManager = configManager;
            _currencyManager = currencyManager;
            _userProfileManager = userProfileManager;
            _cooldownTracker = [];
        }

        public async Task HandleMessageAsync(SocketMessage message)
        {
            if (message is not SocketUserMessage userMessage || message.Author.IsBot) return;

            // Grab monetized channels list
            List<ulong> monetizedChannels = _configManager.GetMonetizedChannels();

            if (!monetizedChannels.Contains(userMessage.Channel.Id)) return;

            ulong userId = userMessage.Author.Id;
            DateTime now = DateTime.UtcNow;

            // If userId has sent a message in less time than the cooldown amount, end process.
            if (_cooldownTracker.TryGetValue(userId, out DateTime lastMessageTime) && now - lastMessageTime < _configManager.GetMessageCooldownAmount())
            {
                return;
            }

            _cooldownTracker[userId] = now;
            if (_userProfileManager.IsUserRegistered(userId))
            {
                _currencyManager.AddAmountToUserCurrency(_userProfileManager.GetUserProfile(userId), _configManager.GetMessageValueAmount());
                _userProfileManager.SaveAndReloadUserProfileList();
            }
        }
    }
}
