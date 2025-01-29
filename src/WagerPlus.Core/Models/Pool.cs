using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WagerPlus.Core.Enums;

namespace WagerPlus.Core.Models
{
    public class Pool
    {
        // Basic Info
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public PoolType Type { get; set; }
        public string TypeToString => Type.ToString();
        public DateTime CreatedOn { get; set; }

        // Choices
        public List<Choice> Choices { get; set; }

        // Dynamic Info
        public PoolStatus Status { get; set; }
        public string StatusToString => Status.ToString();
        public decimal? Odds { get; set; }
        public int AmountTotal { get; set; }
        public List<Wager> Wagers { get; set; }

        // Status Timestamps
        public DateTime Opened { get; set; }
        public DateTime Closed { get; set; }
        public DateTime Resolved { get; set; }

        // Creator Info
        public ulong OwnerDiscordId { get; set; }
        public string OwnerDisplayName { get; set; }

        public Pool(string name, PoolType poolType, ulong ownerDIscordId, string ownerDisplayName, string? description = null)
        {
            Id = new(); 
            Name = name;
            Description = description ?? string.Empty;
            Type = poolType;
            CreatedOn = DateTime.Now;
            Choices = [];
            Status = PoolStatus.Closed;
            Wagers = [];
            OwnerDiscordId = ownerDIscordId;
            OwnerDisplayName = ownerDisplayName;
        }
    }
}
