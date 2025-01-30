using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WagerPlus.Core.Enums.PoolEnums;

namespace WagerPlus.Core.Models.Pools
{
    public class Pool
    {
        // Basic Info
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public PoolType Type { get; set; }
        public DateTime CreatedOn { get; set; }

        // Targets
        public Dictionary<int, Target> Targets { get; set; }

        // Choices
        public Dictionary<int, Choice> Choices { get; set; }

        // Dynamic Info
        public PoolStatus Status { get; set; }
        public int AmountTotal { get; set; }
        public List<Wager> Wagers { get; set; }

        // Status Timestamps
        public DateTime Opened { get; set; }
        public DateTime Closed { get; set; }
        public DateTime Resolved { get; set; }

        // Creator Info
        public ulong OwnerDiscordId { get; set; }
        public string OwnerDisplayName { get; set; }

        public Pool(string name, PoolType poolType, ulong ownerDiscordId, string ownerDisplayName, string? description = null)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description ?? string.Empty;
            Type = poolType;
            CreatedOn = DateTime.Now;
            Targets = [];
            Choices = [];
            Status = PoolStatus.Closed;
            Wagers = [];
            OwnerDiscordId = ownerDiscordId;
            OwnerDisplayName = ownerDisplayName;
        }

        public void AddChoiceToDictionary(Choice choice)
        {
            Choices.Add(Choices.Count + 1, choice);
        }

        public void AddTargetToDictionary(Target target)
        {
            Targets.Add(Targets.Count + 1, target);
        }

        public void AddWagerToList(Wager wager)
        {
            Wagers.Add(wager);
        }
    }
}
