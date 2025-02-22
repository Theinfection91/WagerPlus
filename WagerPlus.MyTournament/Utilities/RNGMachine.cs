using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WagerPlus.MyTournament.Enums;
using WagerPlus.MyTournament.Models;
using WagerPlus.MyTournament.Models.Staff;

namespace WagerPlus.MyTournament.Utilities
{
    public class RNGMachine
    {
        private Random _random;
        public RNGMachine()
        {
            _random = new();
        }

        public string GetRandomName()
        {
            Array names = Enum.GetValues(typeof(NPCNames));
            return names.GetValue(_random.Next(names.Length)).ToString();
        }

        public Bookkeeper GenerateRandomBookkeeper(bool isHighLevel)
        {
            if (!isHighLevel)
            {
                Bookkeeper bookkeeper = new(GetRandomName())
                {
                    Drive = _random.Next(7),
                    Adaptability = _random.Next(7),
                    Experience = _random.Next(7)
                };
                bookkeeper.CalculateSalary();
                return bookkeeper;
            }
            else
            {
                Bookkeeper bookkeeper = new(GetRandomName())
                {
                    Drive = _random.Next(11),
                    Adaptability = _random.Next(11),
                    Experience = _random.Next(11)
                };
                bookkeeper.CalculateSalary();
                return bookkeeper;
            }
        }

        public Promoter GenerateRandomPromoter(bool isHighLevel)
        {
            if (!isHighLevel)
            {
                Promoter promoter = new(GetRandomName())
                {
                    Drive = _random.Next(7),
                    Adaptability = _random.Next(7),
                    Experience = _random.Next(7)
                };
                promoter.CalculateSalary();
                return promoter;
            }
            else
            {
                Promoter promoter = new(GetRandomName())
                {
                    Drive = _random.Next(11),
                    Adaptability = _random.Next(11),
                    Experience = _random.Next(11)
                };
                promoter.CalculateSalary();
                return promoter;
            }
        }

        public TeamCoordinator GenerateRandomTeamCoordinator(bool isHighLevel)
        {
            if (!isHighLevel)
            {
                TeamCoordinator teamCoordinator = new(GetRandomName())
                {
                    Drive = _random.Next(7),
                    Adaptability = _random.Next(7),
                    Experience = _random.Next(7)
                };
                teamCoordinator.CalculateSalary();
                return teamCoordinator;
            }
            else
            {
                TeamCoordinator teamCoordinator = new(GetRandomName())
                {
                    Drive = _random.Next(11),
                    Adaptability = _random.Next(11),
                    Experience = _random.Next(11)
                };
                teamCoordinator.CalculateSalary();
                return teamCoordinator;
            }
        }

        public Combatant GenerateRandomCombatant(int teamCoordinatorScore)
        {
            int scoreBonus = teamCoordinatorScore / 3;
            return new Combatant(GetRandomName())
            {
                Finesse = _random.Next(5 + (scoreBonus)),
                Composure = _random.Next(5 + (scoreBonus)),
                Wisdom = _random.Next(5 + (scoreBonus)),
            };
        }
    }
}
