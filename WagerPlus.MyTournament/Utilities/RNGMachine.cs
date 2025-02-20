using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WagerPlus.MyTournament.Enums;
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
    }
}
