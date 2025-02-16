//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Discord;
//using Discord.Interactions;
//using WagerPlus.Bot.PreconditionAttributes;
//using WagerPlus.CommandLogic.DonationCommands;

//namespace WagerPlus.Bot.SlashCommands
//{
//    [Group("donations", "Donation related commands to donate via PayPal.")]
//    public class DonationCommands : InteractionModuleBase<SocketInteractionContext>
//    {
//        private TestDonateLogic _testDonateLogic;
//        public DonationCommands(TestDonateLogic testDonateLogic)
//        {
//            _testDonateLogic = testDonateLogic;
//        }

//        [SlashCommand("test_donate", "Testing paypal donations")]
//        [RequireCurrencySetup]
//        [RequireUserRegistered]
//        public async Task TestDonateAsync(
//            [Summary("amount", "The amount to donate")] decimal amount)
//        {
//            await _testDonateLogic.TestDonateProcess(amount, Context);
//        }
//    }
//}
