using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Interactions;
using WagerPlus.Managers;
using WagerPlus.MyTournament.Models;

namespace WagerPlus.CommandLogic.FunCommands.MyTournamentCommands
{
    public class MyTournamentRegisterLogic : Logic
    {
        private MyTournamentManager _myTournamentManager;
        public MyTournamentRegisterLogic(MyTournamentManager myTournamentManager) : base("MyTournament Begin")
        {
            _myTournamentManager = myTournamentManager;
        }

        public string MyTournamentRegisterProcess(SocketInteractionContext context)
        {
            if (_myTournamentManager.IsUserRegistered(context.User.Id))
            {
                return $"{context.User.Id} is already registered in the MyTournament Database.";
            }

            Tournament tournament = new(context.User.Id);

            _myTournamentManager.AddTournamentToDatabase(tournament);
            return $"Welcome to the big leagues, kid... You've been picked to run your own Super Shock Tournament Franchine. Don't ask by who... just know that they've been watching your journey and are impressed. They feel it's time to put your elite skills of instagib and irresponsible gambling to the ultimate test: **Making them even more money**\n\n*Don't worry... there's a little something in it for you as well.* At first you'll earn a low percentage but as you level up you'll earn more and more.\n\nTo get you started you've been gifted `{tournament.Arena.Name}` which will serve as your first 'Arena' where your Tournament is hosted and every match in the tournament will be played. You can level up Arenas with the currency you earn and even use an Arena towards a purchase of different, better Arenas later on.\n\nYou'll also be hiring staff to help like the Bookkeeper, Promoter, and Team Coordinator. Make sure to have funds in your Tournament's Bankroll to keep them paid and happy or they will quit.\n\nThe game works on Phases to progress and keep things in line. The first phase is the 'Executive' phase where you can hire and fire staff members. You'll need one of the each that I mentioned above to even begin thinking about starting your tourament. Typing `/my_tournament staff` will start to point you in the right direction.\n\nFor more advanced help type `/my_tournament help` and choose a command that fits what you're looking for.\n\n**Good Luck**";
        }
    }
}
