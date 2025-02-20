using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using WagerPlus.MyTournament.Enums;

namespace WagerPlus.MyTournament.Models.Arenas
{
    public class Arena
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public ArenaQuality Quality { get; set; }
        public int Level { get; set; }
        public int MaxLevel { get; set; }
        public int Capacity { get; set; }
        public int AdmissionFee { get; set; }
        public int MarketValue { get; set; }
        public int LevelUpBaseFee { get; set; }

        public Arena(string id, string name, ArenaQuality quality, int level, int maxLevel, int capacity, int admissionFee, int marketValue, int levelUpBaseFee)
        {
            Id = id;
            Name = name;
            Quality = quality;
            Level = level;
            MaxLevel = maxLevel;
            Capacity = capacity;
            AdmissionFee = admissionFee;
            MarketValue = marketValue;
            LevelUpBaseFee = levelUpBaseFee;
        }
    }
}
